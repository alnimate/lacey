using System.Threading.Tasks;

namespace Lacey.Medusa.Boost.Services.Services
{
    public interface IYoutubeBooster
    {
        Task Boost(string channelId);
    }
}