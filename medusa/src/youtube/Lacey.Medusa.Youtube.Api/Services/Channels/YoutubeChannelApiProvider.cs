using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Services.Auth;
using Lacey.Medusa.Youtube.Api.Services.Common;
using Lacey.Medusa.Youtube.Common.Interfaces;
using Lacey.Medusa.Youtube.Common.Models;

namespace Lacey.Medusa.Youtube.Api.Services.Channels
{
    public sealed class YoutubeChannelApiProvider : YoutubeService, IYoutubeChannelProvider
    {
        public YoutubeChannelApiProvider(IYoutubeAuthProvider youtubeAuthProvider) : 
            base(youtubeAuthProvider)
        {
        }

        public async Task<YoutubeChannel> GetYoutubeChannel(string channelId)
        {
            var channelInfo = await this.GetChannelInfo(channelId);
            var videos = await this.GetChannelVideos(channelId);

            return new YoutubeChannel(channelInfo, videos);
        }

        private async Task<IEnumerable<YoutubeVideo>> GetChannelVideos(string channelId)
        {
            var request = this.Youtube.Search.List("snippet");
            request.Order = SearchResource.ListRequest.OrderEnum.Date;
            request.MaxResults = 50;
            request.ChannelId = channelId;

            var videosList = new List<YoutubeVideo>();
            var nextPageToken = string.Empty;
            while (nextPageToken != null)
            {
                request.PageToken = nextPageToken;
                var response = await request.ExecuteAsync();

                var videos = response.Items.Select(v => new YoutubeVideo(v.Id.VideoId,
                    v.Snippet.Title,
                    v.Snippet.Description,
                    v.Snippet.PublishedAt));
                videosList.AddRange(videos);

                nextPageToken = response.NextPageToken;
            }

            return videosList;
        }

        private async Task<YoutubeChannelInfo> GetChannelInfo(string channelId)
        {
            var request = this.Youtube.Channels.List("snippet");
            request.Id = channelId;
            var response = await request.ExecuteAsync();
            var channel = response.Items.First();

            return new YoutubeChannelInfo(channel.Id,
                channel.Snippet.Title,
                channel.Snippet.Description);
        }
    }

}