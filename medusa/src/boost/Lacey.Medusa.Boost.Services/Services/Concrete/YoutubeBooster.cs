using System;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Boost.Services.Extensions;
using Lacey.Medusa.Boost.Services.Utils;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Boost.Services.Services.Concrete
{
    public sealed class YoutubeBooster : IYoutubeBooster
    {
        private readonly IYoutubeBoostProvider youtubeProvider;

        private readonly ILogger logger;

        private readonly IChannelsService channelsService;

        private readonly IVideosService videosService;

        private readonly string outputFolder;

        public YoutubeBooster(
            IYoutubeBoostProvider youtubeProvider,
            ILogger<YoutubeBooster> logger,
            string outputFolder,
            IChannelsService channelsService,
            IVideosService videosService)
        {
            this.youtubeProvider = youtubeProvider;
            this.logger = logger;
            this.outputFolder = outputFolder;
            this.channelsService = channelsService;
            this.videosService = videosService;
        }

        public async Task Boost(string channelId, int interval)
        {
            var channel = await this.channelsService.GetChannelMetadata(channelId);
            var localVideos = await this.videosService.GetChannelVideos(channelId);

            while (true)
            {
                var randomVideo = localVideos.PickRandom();
                var video = await this.youtubeProvider.GetVideo(randomVideo.VideoId);
                if (video?.Snippet == null || 
                    video.Snippet.Tags?.Count == 0)
                {
                    continue;
                }

                var similarVideo = (await this.youtubeProvider.FindVideosByTags(
                    video.Snippet.Tags.ToArray(), 1)).FirstOrDefault();

                if (similarVideo == null ||
                    similarVideo.Snippet.ChannelId == channel.OriginalChannelId)
                {
                    continue;
                }

                try
                {
                    var comment = await this.youtubeProvider.AddComment(
                        similarVideo.Id.VideoId,
                        video.GetBoostText());
                    this.logger.LogTrace($"{similarVideo.GetYoutubeUrl()}");
                }
                catch (Exception e)
                {
                    this.logger.LogError(e.Message);
                }

                ConsoleUtils.WaitMin(interval);
            }
        }
    }
}