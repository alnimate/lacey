using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InstagramApiSharp.Classes.Models;
using Lacey.Medusa.Common.Cli.Utils;
using Lacey.Medusa.Instagram.Api.Services;
using Lacey.Medusa.Instagram.Domain.Entities;
using Lacey.Medusa.Instagram.Services.Common.Services;
using Lacey.Medusa.Instagram.Services.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lacey.Medusa.Instagram.Services.Transfer.Services.Concrete
{
    public sealed class TransferService : InstagramApiService, ITransferService
    {
        #region Properties/Constructors

        private readonly IChannelsService channelsService;

        private readonly IMediaService mediaService;

        private readonly string outputFolder;

        public TransferService(
            IInstagramProvider instagramProvider,
            ILogger<TransferService> logger,
            string outputFolder,
            IChannelsService channelsService,
            IMediaService mediaService) : base(instagramProvider, logger)
        {
            this.outputFolder = outputFolder;
            this.channelsService = channelsService;
            this.mediaService = mediaService;

            this.InstagramProvider.Login().Wait();
        }

        #endregion

        #region Apply metadata

        public async Task ApplyMediaMetadataLast(string sourceChannelId, string destChannelId)
        {
            await this.ApplyMediaMetadata(sourceChannelId, destChannelId, true);
        }

        public async Task ApplyMediaMetadataAll(string sourceChannelId, string destChannelId)
        {
            await this.ApplyMediaMetadata(sourceChannelId, destChannelId, false);
        }

        private async Task ApplyMediaMetadata(
            string sourceChannelId, 
            string destChannelId,
            bool isOnlyLast)
        {
            var channel = await this.channelsService.GetChannelMetadata(destChannelId);
            var medias = await this.mediaService.GetTransferMedias(sourceChannelId, destChannelId);
            var now = DateTime.UtcNow;

            var mediaList = isOnlyLast
                ? await this.InstagramProvider.GetUserMediaLast(channel.ChannelId)
                : await this.InstagramProvider.GetUserMediaAll(channel.ChannelId);

            foreach (var localMedia in medias.OrderByDescending(m => m.CreatedAt))
            {
                if (isOnlyLast && (now - localMedia.CreatedAt).TotalHours > 8)
                {
                    continue;
                }

                try
                {
                    var media = mediaList.FirstOrDefault(m => 
                        m.Caption?.MediaId == localMedia.MediaId ||
                        m.Caption?.Text == localMedia.Name);
                    if (media?.Caption == null || 
                        string.IsNullOrEmpty(media.Caption.MediaId))
                    {
                        continue;
                    }

                    var originalMedia = localMedia.Description.Deserialize<InstaMedia>();
                    if (originalMedia.Caption == null ||
                        originalMedia.Location == null)
                    {
                        continue;
                    }

                    var result = await this.InstagramProvider.EditMediaAsync(
                        media.Caption.MediaId,
                        originalMedia.Caption.Text,
                        originalMedia.Location,
                        originalMedia.UserTags.AsUpload(channel.ChannelId));

                    if (!result.Succeeded)
                    {
                        this.Logger.LogTrace($"{result.Info?.Message}");
                        continue;
                    }

                    this.Logger.LogTrace($"\"{originalMedia.Caption.Text}\" updated.");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
                catch (Exception e)
                {
                    this.Logger.LogTrace(e.Message);
                }
            }
        }

        #endregion

        #region Transfer metadata

        public async Task TransferMediaLast(string sourceChannelId, string destChannelId)
        {
            InstaMediaList mediaList;
            while (true)
            {
                try
                {
                    mediaList = await this.InstagramProvider.GetUserMediaLast(sourceChannelId);
                    break;
                }
                catch (Exception e)
                {
                    this.Logger.LogError(e.Message);
                    ConsoleUtils.WaitSec(5 * 60);
                }
            }

            this.DoTransferMedia(sourceChannelId, destChannelId, mediaList).Wait();
        }

        public async Task TransferMedia(string sourceChannelId, string destChannelId)
        {
            var mediaList = await this.InstagramProvider.GetUserMediaAll(sourceChannelId);

            this.DoTransferMedia(sourceChannelId, destChannelId, mediaList).Wait();
        }

        private async Task DoTransferMedia(
            string sourceChannelId,
            string destChannelId,
            InstaMediaList mediaList)
        {
            ChannelEntity channel;
            IReadOnlyList<MediaEntity> saved;

            while (true)
            {
                try
                {
                    channel = await this.channelsService.GetChannelMetadata(destChannelId);
                    saved = await this.mediaService.GetTransferMedias(sourceChannelId, destChannelId);
                    break;
                }
                catch (Exception e)
                {
                    this.Logger.LogError(e.Message);
                    ConsoleUtils.WaitSec(5 * 60);
                }
            }

            foreach (var media in mediaList.OrderBy(m => m.DeviceTimeStamp))
            {
                if (media.Caption?.MediaId == null ||
                    saved.Any(m => m.OriginalMediaId == media.Caption.MediaId || 
                                   m.OriginalMediaId == media.Code))
                {
                    continue;
                }

                try
                {
                    var name = media.Caption.Text;
                    this.Logger.LogTrace($"Uploading \"{name}\"...");
                    var results = await this.InstagramProvider.UploadMedia(media, this.outputFolder);
                    foreach (var result in results)
                    {
                        if (!result.Succeeded)
                        {
                            this.Logger.LogTrace($"{result.Info?.Message}");
                            continue;
                        }
                        this.Logger.LogTrace($"\"{name}\" uploaded.");

                        this.Logger.LogTrace($"Editing \"{name}\"...");
                        var editResult = await this.InstagramProvider.EditMediaAsync(
                            result.Value.Caption.MediaId,
                            media.Caption.Text,
                            media.Location,
                            media.UserTags.AsUpload(channel.ChannelId));
                        if (!editResult.Succeeded)
                        {
                            this.Logger.LogTrace($"{editResult.Info?.Message}");
                        }
                        else
                        {
                            this.Logger.LogTrace($"\"{name}\" edited.");
                        }

                        this.Logger.LogTrace($"Saving \"{name}\"...");
                        await this.mediaService.Add(channel.Id, result.Value.Caption.MediaId, media);
                        this.Logger.LogTrace($"\"{name}\" saved.");
                    }

                    ConsoleUtils.WaitSec(5);
                }
                catch (Exception e)
                {
                    this.Logger.LogError(e.Message);
                    ConsoleUtils.WaitSec(20);
                }
            }
        }

        #endregion

        #region Save metadata

        public async Task SaveMedia(string sourceChannelId, string destChannelId)
        {
            var channel = await this.channelsService.GetChannelMetadata(destChannelId);
            var saved = await this.mediaService.GetTransferMedias(sourceChannelId, destChannelId);
            var mediaList = await this.InstagramProvider.GetUserMediaAll(sourceChannelId);
            foreach (var media in mediaList.OrderBy(m => m.DeviceTimeStamp))
            {
                if (media.Caption == null ||
                    string.IsNullOrEmpty(media.Caption.MediaId) ||
                    saved.Any(m => m.OriginalMediaId == media.Caption.MediaId))
                {
                    continue;
                }

                this.Logger.LogTrace($"Saving \"{media.Caption.Text}\"...");
                await this.mediaService.Add(channel.Id, media.Caption.MediaId, media);
                this.Logger.LogTrace($"\"{media.Caption.Text}\" saved.");
            }
        }

        public async Task UploadMedia(string sourceChannelId, string destChannelId)
        {
            var medias = await this.mediaService.GetTransferMedias(sourceChannelId, destChannelId);
            var now = DateTime.UtcNow;

            var mediaList = new List<InstaMedia>();
            foreach (var media in medias)
            {
                if ((now - media.CreatedAt).TotalHours > 8)
                {
                    continue;
                }

                try
                {
                    var m = JsonConvert.DeserializeObject<InstaMedia>(media.Description,
                        new JsonSerializerSettings
                        {
                            Error = delegate (object sender, ErrorEventArgs args)
                            {
                                args.ErrorContext.Handled = true;
                            }
                        });

                    mediaList.Add(m);
                }
                catch (Exception e)
                {
                    this.Logger.LogTrace(e.Message);
                }
            }

            foreach (var media in mediaList.OrderBy(m => m.DeviceTimeStamp))
            {
                var name = media.Caption != null ? media.Caption.Text : media.Code;
                this.Logger.LogTrace($"Uploading \"{name}\"...");
                var results = await this.InstagramProvider.UploadMedia(media, this.outputFolder);
                foreach (var result in results)
                {
                    if (!result.Succeeded)
                    {
                        this.Logger.LogTrace($"{result.Info?.Message}");
                        continue;
                    }

                    this.Logger.LogTrace($"\"{name}\" uploaded.");
                }

                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
        }

        #endregion
    }
}