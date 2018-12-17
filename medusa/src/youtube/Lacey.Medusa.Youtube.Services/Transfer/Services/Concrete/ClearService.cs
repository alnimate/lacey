using System;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Services;
using Lacey.Medusa.Youtube.Services.Common.Services;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete
{
    public class ClearService : YoutubeApiService, IClearService
    {
        private readonly IChannelsService channelsService;

        private readonly IVideosService videosService;

        private readonly IPlaylistsService playlistsService;

        public ClearService(
            IYoutubeProvider youtubeProvider, 
            ILogger<ClearService> logger, 
            IChannelsService channelsService, 
            IVideosService videosService, 
            IPlaylistsService playlistsService) : 
            base(youtubeProvider, logger)
        {
            this.channelsService = channelsService;
            this.videosService = videosService;
            this.playlistsService = playlistsService;
        }

        public async Task ClearChannel(string channelId)
        {
            await this.DeletePlaylists(channelId);

            await this.DeleteSections(channelId);

            await this.DeleteSubscriptions(channelId);

            await this.DeleteComments(channelId);

            await this.DeleteVideos(channelId);

            await this.DeleteMetadata(channelId);
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

            await this.videosService.DeleteChannelVideos(channelId);
        }

        private async Task DeletePlaylists(string channelId)
        {
            try
            {
                this.Logger.LogTrace($"Deleting playlists for channel [{channelId}]...");

                var playlists = await this.YoutubeProvider.GetPlaylists(channelId);
                foreach (var playlist in playlists)
                {
                    await this.YoutubeProvider.DeletePlaylistItems(playlist.Id);
                }

                await this.YoutubeProvider.DeletePlaylists(channelId);
                await this.playlistsService.DeleteChannelPlaylists(channelId);
                this.Logger.LogTrace($"Playlists for channel [{channelId}] deleted.");
            }
            catch (Exception exc)
            {
                this.Logger.LogError(exc.Message);
            }
        }

        private async Task DeleteSections(string channelId)
        {
            try
            {
                this.Logger.LogTrace($"Deleting sections for channel [{channelId}]...");
                await this.YoutubeProvider.DeleteSections(channelId);
                this.Logger.LogTrace($"Sections for channel [{channelId}] deleted.");
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

        private async Task DeleteMetadata(string channelId)
        {
            try
            {
                this.Logger.LogTrace($"Deleting metadata for channel [{channelId}]...");
                await this.YoutubeProvider.DeleteMetadata(channelId);
                await this.channelsService.DeleteChannel(channelId);
                this.Logger.LogTrace($"Metadata for channel [{channelId}] deleted.");
            }
            catch (Exception exc)
            {
                this.Logger.LogError(exc.Message);
            }
        }
    }
}