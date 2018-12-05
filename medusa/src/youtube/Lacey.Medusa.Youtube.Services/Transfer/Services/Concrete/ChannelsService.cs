using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Common.Dal.Dal;
using Lacey.Medusa.Common.Services.Services.Common;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Domain.Entities;
using Lacey.Medusa.Youtube.Services.Transfer.Mappers;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete
{
    public sealed class ChannelsService : UnitOfWorkService, IChannelsService
    {
        private readonly IMapper mapper;

        public ChannelsService(
            IUnitOfWorkFactory unitOfWorkFactory, 
            IMapper mapper) : base(unitOfWorkFactory)
        {
            this.mapper = mapper;
        }

        public async Task<ChannelEntity> GetTransferMetadata(string originalChannelId, string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();

                return await ChannelsMapper.MapToTransferMetadata(
                    channelsRep.GetAll(),
                    originalChannelId,
                    channelId);
            }
        }

        public async Task<ChannelEntity> GetChannelMetadata(string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();

                return await ChannelsMapper.MapToChannelMetadata(
                    channelsRep.GetAll(),
                    channelId);
            }
        }

        public async Task<int> AddOrUpdate(string originalChannelId, string channelId, Channel channel)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();
                var entity = this.mapper.Map<ChannelEntity>(channel);

                if (await this.GetTransferMetadata(originalChannelId, channelId) == null)
                {
                    await channelsRep.AddAsync(entity);
                }
                else
                {
                    channelsRep.Update(entity);
                }

                await uow.SaveAsync();
                return entity.Id;
            }
        }

        public async Task DeleteTransfer(string originalChannelId, string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();

                var channel = await this.GetTransferMetadata(originalChannelId, channelId);
                if (channel != null)
                {
                    channelsRep.DeleteById(channel.Id);
                    await uow.SaveAsync();
                }
            }
        }

        public async Task DeleteChannel(string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();

                var channel = await this.GetChannelMetadata(channelId);
                if (channel != null)
                {
                    channelsRep.DeleteById(channel.Id);
                    await uow.SaveAsync();
                }
            }
        }
    }
}