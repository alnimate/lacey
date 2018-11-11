using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Services.Auth;
using Lacey.Medusa.Youtube.Api.Services.Common;
using Lacey.Medusa.Youtube.Common.Interfaces;
using Lacey.Medusa.Youtube.Common.Models.About;
using Lacey.Medusa.Youtube.Common.Models.Common;
using Lacey.Medusa.Youtube.Common.Models.Videos;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Api.Services.Channels
{
    public sealed class YoutubeChannelApiProvider : YoutubeApiService, IYoutubeChannelProvider
    {
        public YoutubeChannelApiProvider(
            IYoutubeAuthProvider youtubeAuthProvider, 
            IMapper mapper,
            ILogger<YoutubeChannelApiProvider> logger) 
            : base(youtubeAuthProvider, mapper, logger)
        {
        }

        public async Task<YoutubeChannel> GetYoutubeChannel(string channelId)
        {
            var request = this.Youtube.Channels.List("snippet");
            request.Id = channelId;
            var response = await request.ExecuteAsync();
            var channel = response.Items.First();

            var videos = await this.GetYoutubeVideos(channelId);
            var about = this.Mapper.Map<YoutubeAbout>(channel.Snippet);

            return new YoutubeChannel(channel.Id,
                channel.Snippet.Title,
                videos,
                about);
        }

        private async Task<YoutubeVideos> GetYoutubeVideos(string channelId)
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

                var videos = this.Mapper.Map<IEnumerable<YoutubeVideo>>(response.Items);
                videosList.AddRange(videos);

                nextPageToken = response.NextPageToken;
            }

            return new YoutubeVideos(videosList);
        }
    }
}