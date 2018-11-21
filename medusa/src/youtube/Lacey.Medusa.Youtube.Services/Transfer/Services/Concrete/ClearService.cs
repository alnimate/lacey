using System;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Services;
using Lacey.Medusa.Youtube.Services.Common.Services;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete
{
    public class ClearService : YoutubeService, IClearService
    {
        public ClearService(
            IYoutubeProvider youtubeProvider, 
            ILogger<ClearService> logger) : 
            base(youtubeProvider, logger)
        {
        }

        public async Task ClearChannel(string channelId)
        {
            await this.DeleteComments(channelId);

            await this.DeleteSubscriptions(channelId);

            await this.DeletePlaylists(channelId);

            await this.DeleteVideos(channelId);

            await this.DeleteMetadata(channelId);
        }

        private async Task DeleteComments(string channelId)
        {
            try
            {
                this.Logger.LogTrace($"Deleting comments for channel [{channelId}]...");
                await this.YoutubeProvider.DeleteComments(channelId);
                this.Logger.LogTrace($"Comments for channel [{channelId}] deleted.");
            }
            catch (Exception exc)
            {
                this.Logger.LogError(exc.Message);
            }
        }

        private async Task DeleteSubscriptions(string channelId)
        {
            try
            {
                this.Logger.LogTrace($"Deleting subscriptions for channel [{channelId}]...");
                await this.YoutubeProvider.DeleteSubscriptions(channelId);
                this.Logger.LogTrace($"Subscriptions for channel [{channelId}] deleted.");
            }
            catch (Exception exc)
            {
                this.Logger.LogError(exc.Message);
            }
        }

        private async Task DeletePlaylists(string channelId)
        {
            try
            {
                this.Logger.LogTrace($"Deleting playlists for channel [{channelId}]...");
                await this.YoutubeProvider.DeletePlaylists(channelId);
                this.Logger.LogTrace($"Playlists for channel [{channelId}] deleted.");
            }
            catch (Exception exc)
            {
                this.Logger.LogError(exc.Message);
            }
        }

        private async Task DeleteVideos(string channelId)
        {
            var videoIds = await this.YoutubeProvider.GetVideoIds(channelId);
            foreach (var videoId in videoIds)
            {
                this.Logger.LogTrace($"Deleting video [{videoId}]...");
                try
                {
                    await this.YoutubeProvider.DeleteVideo(videoId);
                    this.Logger.LogTrace($"Video [{videoId}] deleted.");
                }
                catch (Exception exc)
                {
                    this.Logger.LogError(exc.Message);
                }
            }
        }

        private async Task DeleteMetadata(string channelId)
        {
            try
            {
                this.Logger.LogTrace($"Deleting metadata for channel [{channelId}]...");
                await this.YoutubeProvider.DeleteMetadata(channelId);
                this.Logger.LogTrace($"Metadata for channel [{channelId}] deleted.");
            }
            catch (Exception exc)
            {
                this.Logger.LogError(exc.Message);
            }
        }
    }
}