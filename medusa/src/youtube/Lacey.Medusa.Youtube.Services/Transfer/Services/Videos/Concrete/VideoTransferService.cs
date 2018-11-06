using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Services.Api.Services.Auth;
using Lacey.Medusa.Youtube.Services.Api.Services.Common;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Videos;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Videos.Concrete
{
    public sealed class VideoTransferService : YoutubeService, IVideoTransferService
    {
        public VideoTransferService(IYoutubeAuthProvider youtubeAuthProvider) : base(youtubeAuthProvider)
        {
        }

        public async Task<IEnumerable<SourceVideo>> GetChannelVideos(string channelId)
        {
            var searchListRequest = this.Youtube.Search.List("snippet");
            searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
            searchListRequest.MaxResults = 50;
            searchListRequest.ChannelId = channelId;
            var searchListResult = await searchListRequest.ExecuteAsync();

            return searchListResult.Items.Select(v => new SourceVideo(v.Id.VideoId, 
                v.Snippet.Title,
                v.Snippet.Description,
                v.Snippet.PublishedAt,
                v.Snippet.ChannelId))
                .ToArray();
        }
    }
}