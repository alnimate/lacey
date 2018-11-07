using System.Collections.Generic;

namespace Lacey.Medusa.Youtube.Services.Transfer.Models.Store
{
    public sealed class StoreChannel
    {
        public StoreChannel(
            StoreChannelInfo channel, 
            IEnumerable<StoreVideo> videos)
        {
            Channel = channel;
            Videos = videos;
        }

        public StoreChannelInfo Channel { get; }

        public IEnumerable<StoreVideo> Videos { get; }
    }
}