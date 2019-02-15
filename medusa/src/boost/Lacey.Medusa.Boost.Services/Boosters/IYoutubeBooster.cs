using System;
using System.Threading.Tasks;

namespace Lacey.Medusa.Boost.Services.Boosters
{
    public interface IYoutubeBooster : IDisposable
    {
        Task Boost(string channelId, string instagramChannelId, int interval);
    }
}