using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Boost.Services.Extensions;
using Lacey.Medusa.Boost.Services.Providers;
using Lacey.Medusa.Boost.Services.Utils;
using Lacey.Medusa.Youtube.Domain.Entities;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Microsoft.Extensions.Logging;
using IChannelsService = Lacey.Medusa.Youtube.Services.Transfer.Services.IChannelsService;

namespace Lacey.Medusa.Boost.Services.Boosters.Concrete
{
    public sealed class YoutubeBooster : IYoutubeBooster
    {
        #region Properties/Constructors

        private readonly IYoutubeBoostProvider youtubeProvider;

        private readonly ILogger logger;

        private readonly IChannelsService channelsService;

        private readonly IVideosService videosService;

        private readonly Instagram.Services.Transfer.Services.IChannelsService instagramChannelsService;

        private readonly YoutubeOnYoutubeBooster youtubeBooster;

        private readonly YoutubeOnInstagramBooster instagramBooster;

        public YoutubeBooster(
            IYoutubeBoostProvider youtubeProvider,
            ILogger<YoutubeBooster> logger,
            IChannelsService channelsService,
            IVideosService videosService,
            Instagram.Services.Transfer.Services.IChannelsService instagramChannelsService,
            YoutubeOnYoutubeBooster youtubeBooster, 
            YoutubeOnInstagramBooster instagramBooster)
        {
            this.youtubeProvider = youtubeProvider;
            this.logger = logger;
            this.channelsService = channelsService;
            this.instagramChannelsService = instagramChannelsService;
            this.videosService = videosService;
            this.youtubeBooster = youtubeBooster;
            this.instagramBooster = instagramBooster;
        }

        #endregion

        public async Task Boost(
            string channelId,
            string instagramChannelId,
            int interval)
        {
            ChannelEntity youtubeChannel;
            IReadOnlyList<VideoEntity> youtubeVideos;
            Instagram.Domain.Entities.ChannelEntity instagramChannel;
            while (true)
            {
                try
                {
                    youtubeChannel = await this.channelsService.GetChannelMetadata(channelId);
                    youtubeVideos = await this.videosService.GetChannelVideos(channelId);
                    instagramChannel = await this.instagramChannelsService.GetChannelMetadata(instagramChannelId);
                    break;
                }
                catch (Exception e)
                {
                    this.logger.LogError(e.Message);
                    ConsoleUtils.WaitSec(60);
                }
            }

            while (true)
            {
                try
                {
                    var randomVideo = youtubeVideos.PickRandom();
                    var video = await this.youtubeProvider.GetVideo(randomVideo.VideoId);

                    await this.youtubeBooster.Boost(youtubeChannel, video);
                    this.WaitNext(interval);

                    await this.instagramBooster.Boost(instagramChannel, youtubeChannel, video);
                    this.WaitNext(interval);
                }
                catch (Exception e)
                {
                    this.logger.LogError(e.Message);
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private void WaitNext(int interval)
        {
            var sec = 60 * (interval / 2 - RandomUtils.GetRandom(0, 1))
                      + RandomUtils.GetRandom(0, 60);
            ConsoleUtils.WaitSec(sec);
        }

        #region IDisposable

        public void Dispose()
        {
            this.youtubeProvider.Dispose();
            this.youtubeBooster.Dispose();
        }

        #endregion
    }
}