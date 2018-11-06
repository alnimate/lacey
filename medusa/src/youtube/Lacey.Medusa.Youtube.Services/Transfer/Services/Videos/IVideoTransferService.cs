using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Videos;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Videos
{
    public interface IVideoTransferService
    {
        Task<IEnumerable<SourceVideo>> GetChannelVideos(string channelId);
    }
}