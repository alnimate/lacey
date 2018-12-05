using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Common.Dal.Dal;
using Lacey.Medusa.Common.Services.Services.Common;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Domain.Entities;
using Lacey.Medusa.Youtube.Services.Transfer.Mappers;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete
{
    public sealed class VideosService : UnitOfWorkService, IVideosService
    {
        private readonly IMapper mapper;

        public VideosService(
            IUnitOfWorkFactory unitOfWorkFactory, 
            IMapper mapper) : base(unitOfWorkFactory)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<VideoEntity>> GetVideos(string originalChannelId, string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();
                var videosRep = uow.GetRepository<VideoEntity>();

                return await VideosMapper.MapToVideos(
                    channelsRep.GetAll(),
                    videosRep.GetAll(),
                    originalChannelId,
                    channelId);
            }
        }

        public async Task<int> Add(string originalChannelId, string channelId, Video video)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var videosRep = uow.GetRepository<VideoEntity>();
                var entity = this.mapper.Map<VideoEntity>(video);

                await videosRep.AddAsync(entity);

                await uow.SaveAsync();
                return entity.Id;
            }
        }
    }
}