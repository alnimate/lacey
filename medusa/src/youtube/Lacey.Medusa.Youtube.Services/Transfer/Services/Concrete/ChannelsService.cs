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

        public async Task<ChannelEntity> GetChannel(string originalChannelId, string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();

                return await ChannelsMapper.MapToChannel(
                    channelsRep.GetAll(),
                    originalChannelId,
                    channelId);
            }
        }

        public async Task<int> AddOrUpdate(string originalChannelId, string channelId, Channel channel)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();
                var entity = this.mapper.Map<ChannelEntity>(channel);

                if (await this.GetChannel(originalChannelId, channelId) == null)
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
    }
}