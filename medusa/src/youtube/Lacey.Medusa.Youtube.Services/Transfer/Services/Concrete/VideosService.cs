using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Common.Dal.Dal;
using Lacey.Medusa.Common.Services.Services.Common;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Domain.Entities;
using Lacey.Medusa.Youtube.Services.Transfer.Mappers;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IReadOnlyList<VideoEntity>> GetTransferVideos(string originalChannelId, string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();
                var videosRep = uow.GetRepository<VideoEntity>();

                return await VideosMapper.MapToTransferVideos(
                    channelsRep.GetAll(),
                    videosRep.GetAll(),
                    originalChannelId,
                    channelId);
            }
        }

        public async Task<IReadOnlyList<VideoEntity>> GetChannelVideos(string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();
                var videosRep = uow.GetRepository<VideoEntity>();

                return await VideosMapper.MapToChannelVideos(
                    channelsRep.GetAll(),
                    videosRep.GetAll(),
                    channelId);
            }
        }

        public async Task<int> Add(int channelId, string originalVideoId, Video video)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var videosRep = uow.GetRepository<VideoEntity>();
                var entity = this.mapper.Map<VideoEntity>(video);
                entity.ChannelId = channelId;
                entity.OriginalVideoId = originalVideoId;

                await videosRep.AddAsync(entity);

                await uow.SaveAsync();
                return entity.Id;
            }
        }

        public async Task UpdateDescription(string videoId, string description)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var videosRep = uow.GetRepository<VideoEntity>();

                var entity = await VideosMapper.MapToVideo(
                                                videosRep.GetAll(),
                                                videoId);
                entity.Description = description;
                videosRep.Update(entity);

                await uow.SaveAsync();
            }
        }

        public async Task DeleteTransferVideos(string originalChannelId, string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var videosRep = uow.GetRepository<VideoEntity>();

                var videos = await this.GetTransferVideos(originalChannelId, channelId);
                foreach (var video in videos)
                {
                    videosRep.DeleteById(video.Id);
                }

                await uow.SaveAsync();
            }
        }

        public async Task DeleteChannelVideos(string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var videosRep = uow.GetRepository<VideoEntity>();

                var videos = await this.GetChannelVideos(channelId);
                foreach (var video in videos)
                {
                    videosRep.DeleteById(video.Id);
                }

                await uow.SaveAsync();
            }
        }

        public async Task DeleteVideo(string videoId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var videosRep = uow.GetRepository<VideoEntity>();

                var entity = await videosRep.GetAll(e => e.VideoId == videoId).FirstOrDefaultAsync();
                if (entity != null)
                {
                    videosRep.DeleteById(entity.Id);
                    await uow.SaveAsync();
                }
            }
        }

        public async Task<VideoEntity> GetVideo(string videoId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var videosRep = uow.GetRepository<VideoEntity>();

                return await VideosMapper.MapToVideo(
                    videosRep.GetAll(),
                    videoId);
            }
        }
    }
}