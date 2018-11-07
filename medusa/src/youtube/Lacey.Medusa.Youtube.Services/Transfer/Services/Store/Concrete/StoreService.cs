using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Common.Dal.Dal;
using Lacey.Medusa.Common.Services.Services.Common;
using Lacey.Medusa.Youtube.Domain.Entities;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Store;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Store.Concrete
{
    public sealed class StoreService : UnitOfWorkService, IStoreService
    {
        private readonly IMapper mapper;

        public StoreService(
            IUnitOfWorkFactory unitOfWorkFactory, 
            IMapper mapper) : base(unitOfWorkFactory)
        {
            this.mapper = mapper;
        }

        public async Task StoreChannel(StoreChannel channel)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();
                var videosRep = uow.GetRepository<VideoEntity>();

                var channelEntity = this.mapper.Map<ChannelEntity>(channel.Channel);
                channelEntity.CreatedAt = DateTime.UtcNow;
                channelsRep.Add(channelEntity);
                await uow.SaveAsync();

                var videoEntities = this.mapper.Map<IEnumerable<VideoEntity>>(channel.Videos);
                var enumerable = videoEntities as VideoEntity[] ?? videoEntities.ToArray();
                foreach (var videoEntity in enumerable)
                {
                    videoEntity.ChannelId = channelEntity.Id;
                    videoEntity.CreatedAt = DateTime.UtcNow;
                }

                await videosRep.BulkAddAsync(enumerable);
            }
        }
    }
}