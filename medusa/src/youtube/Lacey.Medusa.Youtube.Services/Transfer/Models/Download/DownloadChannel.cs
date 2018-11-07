using System.Collections.Generic;

namespace Lacey.Medusa.Youtube.Services.Transfer.Models.Download
{
    public sealed class DownloadChannel
    {
        public DownloadChannel(
            DownloadChannelInfo channel, 
            IEnumerable<DownloadVideo> videos)
        {
            Channel = channel;
            Videos = videos;
        }

        public DownloadChannelInfo Channel { get; }

        public IEnumerable<DownloadVideo> Videos { get; }
    }
}