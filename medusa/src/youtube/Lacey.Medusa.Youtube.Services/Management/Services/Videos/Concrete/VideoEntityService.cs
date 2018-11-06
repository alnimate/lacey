using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Common.Dal.Dal;
using Lacey.Medusa.Common.Services.Services.Entity;
using Lacey.Medusa.Youtube.Domain.Entities;
using Lacey.Medusa.Youtube.Services.Management.Mappers;
using Lacey.Medusa.Youtube.Services.Management.Models.Videos.Entity;
using Lacey.Medusa.Youtube.Services.Management.Models.Videos.Overviews;

namespace Lacey.Medusa.Youtube.Services.Management.Services.Videos.Concrete
{
    public sealed class VideoEntityService
        : IntIdEntityService<VideoEntity, Video, VideoOverviewsRequest, VideoOverviews>, IVideoEntityService

    {
        public VideoEntityService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
            : base(unitOfWorkFactory, mapper)
        {
        }

        protected override async Task<VideoOverviews> DoGetOverviews(IUnitOfWork uow, VideoOverviewsRequest request)
        {
            var channelsRep = uow.GetRepository<ChannelEntity>();
            var videosRep = uow.GetRepository<VideoEntity>();

            return await VideosMapper.MapToVideoOverviews(
                    request,
                    channelsRep.GetAll(),
                    videosRep.GetAll());
        }
    }
}