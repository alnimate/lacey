using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Domain.Entities;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services
{
    public interface IChannelsService
    {
        Task<ChannelEntity> GetTransferMetadata(string originalChannelId, string channelId);

        Task<ChannelEntity> GetChannelMetadata(string channelId);

        Task<int> AddOrUpdate(string originalChannelId, string channelId, Channel channel);

        Task DeleteTransfer(string originalChannelId, string channelId);

        Task DeleteChannel(string channelId);
    }
}