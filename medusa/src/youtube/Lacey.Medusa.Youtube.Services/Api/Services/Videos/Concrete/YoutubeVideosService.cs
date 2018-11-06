using System.Collections.Generic;
using System.Linq;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Services.Api.Models.Videos;
using Lacey.Medusa.Youtube.Services.Api.Services.Auth;
using Lacey.Medusa.Youtube.Services.Api.Services.Common;

namespace Lacey.Medusa.Youtube.Services.Api.Services.Videos.Concrete
{
    public sealed class YoutubeVideosService : YoutubeService, IYoutubeVideosService
    {
        public YoutubeVideosService(IYoutubeAuthProvider youtubeAuthProvider) : base(youtubeAuthProvider)
        {
        }

        public IEnumerable<YoutubeVideo> GetChannelVideos(string channelId)
        {
            var searchListRequest = this.Youtube.Search.List("snippet");
            searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
            searchListRequest.MaxResults = 50;
            searchListRequest.ChannelId = channelId;
            var searchListResult = searchListRequest.Execute();

            return searchListResult.Items.Select(v => new YoutubeVideo(v.Id.VideoId, 
                v.Snippet.Title,
                v.Snippet.Description,
                v.Snippet.PublishedAt,
                v.Snippet.ChannelId))
                .ToArray();
        }
    }
}