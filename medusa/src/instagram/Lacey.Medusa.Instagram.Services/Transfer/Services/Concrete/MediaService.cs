using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InstagramApiSharp.Classes.Models;
using Lacey.Medusa.Common.Services.Services.Common;
using Lacey.Medusa.Instagram.Dal.Dal;
using Lacey.Medusa.Instagram.Domain.Entities;
using Lacey.Medusa.Instagram.Services.Transfer.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Lacey.Medusa.Instagram.Services.Transfer.Services.Concrete
{
    public sealed class MediaService : UnitOfWorkService, IMediaService
    {
        private readonly IMapper mapper;

        public MediaService(
            IInstagramUnitOfWorkFactory unitOfWorkFactory, 
            IMapper mapper) : base(unitOfWorkFactory)
        {
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<MediaEntity>> GetTransferMedias(string originalChannelId, string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();
                var mediasRep = uow.GetRepository<MediaEntity>();

                return await MediaMapper.MapToTransferMedias(
                    channelsRep.GetAll(),
                    mediasRep.GetAll(),
                    originalChannelId,
                    channelId);
            }
        }

        public async Task<IReadOnlyList<MediaEntity>> GetChannelMedias(string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();
                var mediasRep = uow.GetRepository<MediaEntity>();

                return await MediaMapper.MapToChannelMedias(
                    channelsRep.GetAll(),
                    mediasRep.GetAll(),
                    channelId);
            }
        }

        public async Task<int> Add(int channelId, string mediaId, InstaMedia media)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var mediasRep = uow.GetRepository<MediaEntity>();
                var entity = this.mapper.Map<MediaEntity>(media);
                entity.ChannelId = channelId;
                entity.MediaId = mediaId;

                await mediasRep.AddAsync(entity);

                await uow.SaveAsync();
                return entity.Id;
            }
        }

        public async Task DeleteTransferMedias(string originalChannelId, string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var mediasRep = uow.GetRepository<MediaEntity>();

                var medias = await this.GetTransferMedias(originalChannelId, channelId);
                foreach (var media in medias)
                {
                    mediasRep.DeleteById(media.Id);
                }

                await uow.SaveAsync();
            }
        }

        public async Task DeleteChannelMedias(string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var mediasRep = uow.GetRepository<MediaEntity>();

                var medias = await this.GetChannelMedias(channelId);
                foreach (var media in medias)
                {
                    mediasRep.DeleteById(media.Id);
                }

                await uow.SaveAsync();
            }
        }

        public async Task DeleteMedia(string mediaId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var mediasRep = uow.GetRepository<MediaEntity>();

                var entity = await mediasRep.GetAll(e => e.MediaId == mediaId).FirstOrDefaultAsync();
                if (entity != null)
                {
                    mediasRep.DeleteById(entity.Id);
                    await uow.SaveAsync();
                }
            }
        }

        public async Task<MediaEntity> GetMedia(string mediaId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var mediasRep = uow.GetRepository<MediaEntity>();

                return await MediaMapper.MapToMedia(
                    mediasRep.GetAll(),
                    mediaId);
            }
        }
    }
}