using System.Collections.Generic;
using System.Threading.Tasks;
using InstagramApiSharp.Classes.Models;
using Lacey.Medusa.Instagram.Domain.Entities;

namespace Lacey.Medusa.Instagram.Services.Transfer.Services
{
    public interface IMediaService
    {
        Task<IReadOnlyList<MediaEntity>> GetTransferMedias(string originalChannelId, string channelId);

        Task<IReadOnlyList<MediaEntity>> GetChannelMedias(string channelId);

        Task<int> Add(int channelId, string mediaId, InstaMedia media);

        Task DeleteTransferMedias(string originalChannelId, string channelId);

        Task DeleteChannelMedias(string channelId);

        Task DeleteMedia(string mediaId);

        Task<MediaEntity> GetMedia(string mediaId);
    }
}