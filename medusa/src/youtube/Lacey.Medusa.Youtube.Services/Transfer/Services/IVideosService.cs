using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Domain.Entities;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services
{
    public interface IVideosService
    {
        Task<IReadOnlyList<VideoEntity>> GetTransferVideos(string originalChannelId, string channelId);

        Task<IReadOnlyList<VideoEntity>> GetChannelVideos(string channelId);

        Task<int> Add(int channelId, string originalVideoId, Video video);

        Task DeleteTransferVideos(string originalChannelId, string channelId);

        Task DeleteChannelVideos(string channelId);

        Task DeleteVideo(string videoId);

        Task<VideoEntity> GetVideo(string videoId);
    }
}