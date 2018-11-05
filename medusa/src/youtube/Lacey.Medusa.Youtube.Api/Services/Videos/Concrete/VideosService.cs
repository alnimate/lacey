using System.Collections.Generic;
using System.Linq;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Services.Auth;
using Lacey.Medusa.Youtube.Api.Services.Common;
using Video = Lacey.Medusa.Youtube.Api.Models.Videos.Video;

namespace Lacey.Medusa.Youtube.Api.Services.Videos.Concrete
{
    public sealed class VideosService : YoutubeService, IVideosService
    {
        public VideosService(IAuthProvider authProvider) : base(authProvider)
        {
        }

        public IEnumerable<Video> GetChannelVideos(string channelId)
        {
            var searchListRequest = this.Youtube.Search.List("snippet");
            searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
            searchListRequest.MaxResults = 50;
            searchListRequest.ChannelId = channelId;
            var searchListResult = searchListRequest.Execute();

            return searchListResult.Items.Select(v => new Video(v.Id.VideoId, 
                v.Snippet.Title,
                v.Snippet.Description,
                v.Snippet.PublishedAt,
                v.Snippet.ChannelId))
                .ToArray();
        }
    }
}