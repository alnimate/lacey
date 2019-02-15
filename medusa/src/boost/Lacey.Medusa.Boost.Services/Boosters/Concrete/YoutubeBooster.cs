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

        private readonly YoutubeOnYoutubeBooster youtubeBooster;

        private readonly YoutubeOnInstagramBooster instagramBooster;

        public YoutubeBooster(
            IYoutubeBoostProvider youtubeProvider,
            ILogger<YoutubeBooster> logger,
            IChannelsService channelsService,
            IVideosService videosService,
            YoutubeOnYoutubeBooster youtubeBooster, 
            YoutubeOnInstagramBooster instagramBooster)
        {
            this.youtubeProvider = youtubeProvider;
            this.logger = logger;
            this.channelsService = channelsService;
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
            ChannelEntity localChannel;
            IReadOnlyList<VideoEntity> localVideos;
            while (true)
            {
                try
                {
                    localChannel = await this.channelsService.GetChannelMetadata(channelId);
                    localVideos = await this.videosService.GetChannelVideos(channelId);
                    break;
                }
                catch (Exception e)
                {
                    this.logger.LogError(e.Message);
                    ConsoleUtils.WaitSec(60);
                }
            }

            var youtubeBoosted = false;
            var instagramBoosted = false;
            while (true)
            {
                try
                {
                    if (youtubeBoosted || instagramBoosted)
                    {
                        var sec = (interval + RandomUtils.GetRandom(0, 1) - 2 * RandomUtils.GetRandom(0, 1)) * 60
                                  + RandomUtils.GetRandom(0, 60);
                        ConsoleUtils.WaitSec(sec);
                    }

                    var randomVideo = localVideos.PickRandom();
                    var localVideo = await this.youtubeProvider.GetVideo(randomVideo.VideoId);

                    instagramBoosted = await this.instagramBooster.Boost(instagramChannelId, localChannel, localVideo);
                    if (!instagramBoosted)
                    {
                        ConsoleUtils.WaitSec(60);
                    }

                    youtubeBoosted = await this.youtubeBooster.Boost(localChannel, localVideo);
                    if (!youtubeBoosted)
                    {
                        ConsoleUtils.WaitSec(60);
                    }
                }
                catch (Exception e)
                {
                    this.logger.LogError(e.Message);
                }
            }
            // ReSharper disable once FunctionNeverReturns
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