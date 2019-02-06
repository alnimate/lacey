using System.Threading.Tasks;
using InstagramApiSharp.Classes.Models;
using Lacey.Medusa.Instagram.Domain.Entities;

namespace Lacey.Medusa.Instagram.Services.Transfer.Services
{
    public interface IChannelsService
    {
        Task<ChannelEntity> GetTransferMetadata(string originalChannelId, string channelId);

        Task<ChannelEntity> GetChannelMetadata(string channelId);

        Task<int> AddOrUpdate(string originalChannelId, string channelId, InstaUserInfo channel);

        Task DeleteTransfer(string originalChannelId, string channelId);

        Task DeleteChannel(string channelId);
    }
}