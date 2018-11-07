using System.Collections.Generic;
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
            var channelRequest = this.Youtube.Channels.List("snippet");
            channelRequest.Id = channelId;
            var channelResponse = await channelRequest.ExecuteAsync();
            var channel = channelResponse.Items.First();

            var videosRequest = this.Youtube.Search.List("snippet");
            videosRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
            videosRequest.MaxResults = 50;
            videosRequest.ChannelId = channelId;

            var videosList = new List<DownloadVideo>();
            var nextPageToken = string.Empty;
            while (nextPageToken != null)
            {
                videosRequest.PageToken = nextPageToken;
                var response = await videosRequest.ExecuteAsync();

                var videos = response.Items.Select(v => new DownloadVideo(v.Id.VideoId,
                    v.Snippet.Title,
                    v.Snippet.Description,
                    v.Snippet.PublishedAt));
                videosList.AddRange(videos);

                nextPageToken = response.NextPageToken;
            }

            var channelInfo = new DownloadChannelInfo(channel.Id, 
                channel.Snippet.Title,
                channel.Snippet.Description);

            return new DownloadChannel(channelInfo, videosList);
        }
    }
}