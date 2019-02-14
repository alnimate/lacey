using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Boost.Services.Extensions;
using Lacey.Medusa.Boost.Services.Utils;
using Lacey.Medusa.Instagram.Services.Transfer.Services;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Models.Const;
using Lacey.Medusa.Youtube.Domain.Entities;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Microsoft.Extensions.Logging;
using IChannelsService = Lacey.Medusa.Youtube.Services.Transfer.Services.IChannelsService;

namespace Lacey.Medusa.Boost.Services.Services.Concrete
{
    public sealed class YoutubeBooster : IYoutubeBooster
    {
        #region Properties/Constructors

        private readonly IYoutubeBoostProvider youtubeProvider;

        private readonly IInstagramBoostProvider instagramProvider;

        private readonly ILogger logger;

        private readonly IChannelsService channelsService;

        private readonly IVideosService videosService;

        private readonly string outputFolder;

        private readonly Instagram.Services.Transfer.Services.IChannelsService instagramChannelService;

        private readonly IMediaService instagramMediaService;

        public YoutubeBooster(
            IYoutubeBoostProvider youtubeProvider,
            IInstagramBoostProvider instagramProvider,
            ILogger<YoutubeBooster> logger,
            string outputFolder,
            IChannelsService channelsService,
            IVideosService videosService,
            Instagram.Services.Transfer.Services.IChannelsService instagramChannelService,
            IMediaService instagramMediaService)
        {
            this.youtubeProvider = youtubeProvider;
            this.instagramProvider = instagramProvider;
            this.logger = logger;
            this.outputFolder = outputFolder;
            this.channelsService = channelsService;
            this.videosService = videosService;
            this.instagramChannelService = instagramChannelService;
            this.instagramMediaService = instagramMediaService;
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

                    instagramBoosted = await this.BoostOnInstagram(instagramChannelId, localChannel, localVideo);
                    if (!instagramBoosted)
                    {
                        ConsoleUtils.WaitSec(60);
                    }

                    youtubeBoosted = await this.BoostOnYoutube(localChannel, localVideo);
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
        }

        private async Task<bool> BoostOnInstagram(
            string instagramChannelId,
            ChannelEntity localChannel,
            Video localVideo)
        {
            var instagramChannel = await this.instagramChannelService.GetChannelMetadata(instagramChannelId);

            return true;
        }

        private async Task<bool> BoostOnYoutube(
            ChannelEntity localChannel, 
            Video localVideo)
        {
            var tags = localVideo.Snippet?.Tags.RemoveAll(new[] { localChannel.Name });
            if (tags == null || !tags.Any())
            {
                return false;
            }

            var similarVideos = (await this.youtubeProvider.FindVideosByTags(
                    tags.ToArray(), 20))
                .Shuffle();

            foreach (var similarVideo in similarVideos)
            {
                if (similarVideo == null
                    || similarVideo.Snippet.ChannelId == localChannel.OriginalChannelId
                    || similarVideo.Snippet.ChannelId == localChannel.ChannelId)
                {
                    continue;
                }

                var video = await this.youtubeProvider.GetVideo(similarVideo.Id.VideoId);
                if (video.ContentDetails.LicensedContent == true)
                {
                    continue;
                }

                if (video.Snippet.LiveBroadcastContent != LiveBroadcastContent.None)
                {
                    continue;
                }

                if (video.Statistics.ViewCount > 10000 ||
                    video.Statistics.CommentCount > 100)
                {
                    continue;
                }

                await this.youtubeProvider.AddComment(
                    similarVideo.Snippet.ChannelId,
                    similarVideo.Id.VideoId,
                    localVideo.GetBoostText());

                this.logger.LogTrace($"{similarVideo.GetYoutubeUrl()}");
                return true;
            }

            return false;
        }

        #region IDisposable

        public void Dispose()
        {
            this.youtubeProvider.Dispose();
        }

        #endregion
    }
}