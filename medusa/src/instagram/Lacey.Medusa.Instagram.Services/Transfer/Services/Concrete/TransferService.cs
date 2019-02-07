using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Instagram.Api.Services;
using Lacey.Medusa.Instagram.Services.Common.Services;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Instagram.Services.Transfer.Services.Concrete
{
    public sealed class TransferService : InstagramApiService, ITransferService
    {
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
        }

        public async Task SaveAllMedia(string sourceChannelId, string destChannelId)
        {
            var channel = await this.channelsService.GetChannelMetadata(destChannelId);
            var saved = await this.mediaService.GetTransferMedias(sourceChannelId, destChannelId);
            var mediaList = await this.InstagramProvider.GetUserMediaAll(sourceChannelId);
            foreach (var media in mediaList)
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

        public async Task TransferAllMedia(string sourceChannelId, string destChannelId)
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
    }
}