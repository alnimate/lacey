using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Common.Dal.Dal;
using Lacey.Medusa.Common.Services.Services.Common;
using Lacey.Medusa.Common.Validation.Extensions;
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
                await channelsRep.AddAsync(channelEntity);
                await uow.SaveAsync();

                foreach (var video in channel.Videos)
                {
                    video.ChannelId = channelEntity.Id;
                }

                var validVideos = channel.Videos.ValidationFilter(out var invalidVideos);
                channel.Videos = validVideos;
                channel.InvalidVideos = invalidVideos;

                var videoEntities = this.mapper.Map<IEnumerable<VideoEntity>>(validVideos).ToArray();
                await videosRep.BulkAddAsync(videoEntities);
            }
        }
    }
}