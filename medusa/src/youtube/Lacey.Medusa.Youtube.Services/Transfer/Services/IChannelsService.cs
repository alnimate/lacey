using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Domain.Entities;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services
{
    public interface IChannelsService
    {
        Task<ChannelEntity> GetChannel(string originalChannelId, string channelId);

        Task<int> AddOrUpdate(string originalChannelId, string channelId, Channel channel);
    }
}