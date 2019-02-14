using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InstagramApiSharp.Classes.Models;
using Lacey.Medusa.Instagram.Api.Services;
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
            var medias = await this.mediaService.GetTransferMedias(sourceChannelId, destChannelId);
            var now = DateTime.UtcNow;

            foreach (var localMedia in medias.OrderByDescending(m => m.CreatedAt))
            {
                if (isOnlyLast && (now - localMedia.CreatedAt).TotalHours > 8)
                {
                    continue;
                }

                try
                {
                    var media = localMedia.Description.Deserialize<InstaMedia>();
                    if (media.Caption == null ||
                        string.IsNullOrEmpty(media.Caption.MediaId))
                    {
                        continue;
                    }

                    var tags = new InstaUserTagUpload[0];
                    if (media.UserTags != null)
                    {
                        tags = media.UserTags.Select(t =>
                        {
                            var tag = new InstaUserTagUpload();

                            if (t.User != null)
                            {
                                tag.Username = t.User.UserName;
                            }

                            if (t.Position != null)
                            {
                                tag.X = t.Position.X;
                                tag.Y = t.Position.Y;
                            }

                            return tag;
                        }).ToArray();
                    }

                    var result = await this.InstagramProvider.EditMediaAsync(
                        media.Caption.MediaId,
                        media.Caption.Text,
                        media.Location,
                        tags);

                    if (!result.Succeeded)
                    {
                        this.Logger.LogTrace($"{result.Info?.Message}");
                        continue;
                    }

                    this.Logger.LogTrace($"\"{media.Caption.Text}\" updated.");
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
            var mediaList = await this.InstagramProvider.GetUserMediaLast(sourceChannelId);

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
            var channel = await this.channelsService.GetChannelMetadata(destChannelId);
            var saved = await this.mediaService.GetTransferMedias(sourceChannelId, destChannelId);
            if (mediaList == null)
            {
                throw new Exception("Can't get media from the Instagram.");
            }
            foreach (var media in mediaList.OrderBy(m => m.DeviceTimeStamp))
            {
                if (saved.Any(m => m.OriginalMediaId == media.Code))
                {
                    continue;
                }

                var name = media.Caption != null ? media.Caption.Text : media.Code;
                this.Logger.LogTrace($"Uploading \"{name}\"...");
                var results = await this.InstagramProvider.UploadMedia(media, this.outputFolder);
                foreach (var result in results)
                {
                    if (!result.Succeeded)
                    {
                        this.Logger.LogTrace($"{result.Info?.Message}");
                        throw new Exception("Something wrong with Instagram service. Please try again later.");
                    }

                    this.Logger.LogTrace($"\"{name}\" uploaded.");

                    this.Logger.LogTrace($"Saving \"{name}\"...");
                    await this.mediaService.Add(channel.Id, media.Code, media);
                    this.Logger.LogTrace($"\"{name}\" saved.");
                }
                Thread.Sleep(TimeSpan.FromSeconds(2));
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
                if (saved.Any(m => m.OriginalMediaId == media.Code))
                {
                    continue;
                }

                this.Logger.LogTrace($"Saving \"{media.Caption?.Text}\"...");
                await this.mediaService.Add(channel.Id, media.Code, media);
                this.Logger.LogTrace($"\"{media.Caption?.Text}\" saved.");
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