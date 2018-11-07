using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Services.Auth;
using Lacey.Medusa.Youtube.Api.Services.Common;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Download;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Download.Concrete
{
    public sealed class DownloadService : YoutubeService, IDownloadService
    {
        public DownloadService(IYoutubeAuthProvider youtubeAuthProvider) : base(youtubeAuthProvider)
        {
        }

        public async Task<DownloadChannel> DownloadChannel(string channelId)
        {
            var searchListRequest = this.Youtube.Search.List("snippet");
            searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
            searchListRequest.MaxResults = 50;
            searchListRequest.ChannelId = channelId;
            var searchListResult = await searchListRequest.ExecuteAsync();

            var channel = new DownloadChannelInfo(channelId, null, null);
            var videos = searchListResult.Items.Select(v => new DownloadVideo(v.Id.VideoId, 
                v.Snippet.Title,
                v.Snippet.Description,
                v.Snippet.PublishedAt))
                .ToArray();

            return new DownloadChannel(channel, videos);
        }
    }
}