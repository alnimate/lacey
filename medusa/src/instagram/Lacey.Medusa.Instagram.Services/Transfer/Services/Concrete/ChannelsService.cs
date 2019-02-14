﻿using System.Threading.Tasks;
using AutoMapper;
using InstagramApiSharp.Classes.Models;
using Lacey.Medusa.Common.Services.Services.Common;
using Lacey.Medusa.Instagram.Dal.Dal;
using Lacey.Medusa.Instagram.Domain.Entities;
using Lacey.Medusa.Instagram.Services.Transfer.Mappers;

namespace Lacey.Medusa.Instagram.Services.Transfer.Services.Concrete
{
    public sealed class ChannelsService : UnitOfWorkService, IChannelsService
    {
        private readonly IMapper mapper;

        public ChannelsService(
            IInstagramUnitOfWorkFactory unitOfWorkFactory, 
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

        public async Task<int> AddOrUpdate(string originalChannelId, string channelId, InstaUserInfo channel)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();
                var entity = this.mapper.Map<ChannelEntity>(channel);
                entity.OriginalChannelId = originalChannelId;
                entity.ChannelId = channelId;

                var metadata = await this.GetTransferMetadata(originalChannelId, channelId);
                if (metadata == null)
                {
                    await channelsRep.AddAsync(entity);
                }
                else
                {
                    entity.Id = metadata.Id;
                    entity.CreatedAt = metadata.CreatedAt;
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