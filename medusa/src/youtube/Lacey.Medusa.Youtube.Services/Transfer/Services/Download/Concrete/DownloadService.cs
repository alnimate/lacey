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
            var channelInfo = await this.DownloadChannelInfo(channelId);
            var videos = await this.DownloadChannelVideos(channelId);

            return new DownloadChannel(channelInfo, videos);
        }

        private async Task<IEnumerable<DownloadVideo>> DownloadChannelVideos(string channelId)
        {
            var request = this.Youtube.Search.List("snippet");
            request.Order = SearchResource.ListRequest.OrderEnum.Date;
            request.MaxResults = 50;
            request.ChannelId = channelId;

            var videosList = new List<DownloadVideo>();
            var nextPageToken = string.Empty;
            while (nextPageToken != null)
            {
                request.PageToken = nextPageToken;
                var response = await request.ExecuteAsync();

                var videos = response.Items.Select(v => new DownloadVideo(v.Id.VideoId,
                    v.Snippet.Title,
                    v.Snippet.Description,
                    v.Snippet.PublishedAt));
                videosList.AddRange(videos);

                nextPageToken = response.NextPageToken;
            }

            return videosList;
        }

        private async Task<DownloadChannelInfo> DownloadChannelInfo(string channelId)
        {
            var request = this.Youtube.Channels.List("snippet");
            request.Id = channelId;
            var response = await request.ExecuteAsync();
            var channel = response.Items.First();

            return new DownloadChannelInfo(channel.Id,
                channel.Snippet.Title,
                channel.Snippet.Description);
        }
    }
}