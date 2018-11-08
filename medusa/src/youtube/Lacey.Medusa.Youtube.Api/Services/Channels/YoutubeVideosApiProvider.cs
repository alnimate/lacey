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
    public sealed class YoutubeVideosApiProvider : YoutubeApiService, IYoutubeVideosProvider
    {
        public YoutubeVideosApiProvider(IYoutubeAuthProvider youtubeAuthProvider)
            : base(youtubeAuthProvider)
        {
        }

        public async Task<IEnumerable<YoutubeVideo>> GetYoutubeVideos(string channelId)
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
    }
}