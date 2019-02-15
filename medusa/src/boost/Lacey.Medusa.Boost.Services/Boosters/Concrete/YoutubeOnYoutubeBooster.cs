using System;
using System.Threading.Tasks;
using Lacey.Medusa.Boost.Services.Extensions;
using Lacey.Medusa.Boost.Services.Providers;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Models.Const;
using Lacey.Medusa.Youtube.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Boost.Services.Boosters.Concrete
{
    public sealed class YoutubeOnYoutubeBooster : IDisposable
    {
        private readonly IYoutubeBoostProvider youtubeProvider;

        private readonly ILogger logger;

        public YoutubeOnYoutubeBooster(
            IYoutubeBoostProvider youtubeProvider, 
            ILogger<YoutubeOnYoutubeBooster> logger)
        {
            this.youtubeProvider = youtubeProvider;
            this.logger = logger;
        }

        public async Task<bool> Boost(
            ChannelEntity localChannel,
            Video localVideo)
        {
            var query = localVideo.GetYoutubeQuery(new[] { localChannel.Name });
            if (string.IsNullOrEmpty(query))
            {
                return false;
            }

            var similarVideos = (await this.youtubeProvider.FindVideos(
                    query, 20))
                .Shuffle();

            foreach (var similarVideo in similarVideos)
            {
                if (similarVideo?.Snippet == null || 
                    similarVideo.Snippet.ChannelId == localChannel.OriginalChannelId || 
                    similarVideo.Snippet.ChannelId == localChannel.ChannelId)
                {
                    continue;
                }

                var video = await this.youtubeProvider.GetVideo(similarVideo.Id.VideoId);
                if (video.ContentDetails?.LicensedContent == true)
                {
                    continue;
                }

                if (video.Snippet.LiveBroadcastContent != LiveBroadcastContent.None)
                {
                    continue;
                }

                if (video.Statistics?.ViewCount > 10000 ||
                    video.Statistics?.CommentCount > 100)
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