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
    public sealed class PlaylistsService : UnitOfWorkService, IPlaylistsService
    {
        private readonly IMapper mapper;

        public PlaylistsService(
            IUnitOfWorkFactory unitOfWorkFactory, 
            IMapper mapper) : base(unitOfWorkFactory)
        {
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<PlaylistEntity>> GetTransferPlaylists(string originalChannelId, string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();
                var playlistsRep = uow.GetRepository<PlaylistEntity>();

                return await PlaylistsMapper.MapToTransferPlaylists(
                    channelsRep.GetAll(),
                    playlistsRep.GetAll(),
                    originalChannelId,
                    channelId);
            }
        }

        public async Task<IReadOnlyList<PlaylistEntity>> GetChannelPlaylists(string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();
                var playlistsRep = uow.GetRepository<PlaylistEntity>();

                return await PlaylistsMapper.MapToChannelPlaylists(
                    channelsRep.GetAll(),
                    playlistsRep.GetAll(),
                    channelId);
            }
        }

        public async Task<int> Add(string originalChannelId, string channelId, Playlist playlist)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var playlistsRep = uow.GetRepository<PlaylistEntity>();
                var entity = this.mapper.Map<PlaylistEntity>(playlist);

                await playlistsRep.AddAsync(entity);

                await uow.SaveAsync();
                return entity.Id;
            }
        }

        public async Task DeleteTransferPlaylists(string originalChannelId, string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var playlistsRep = uow.GetRepository<PlaylistEntity>();

                var playlists = await this.GetTransferPlaylists(originalChannelId, channelId);
                foreach (var playlist in playlists)
                {
                    playlistsRep.DeleteById(playlist.Id);
                }

                await uow.SaveAsync();
            }
        }

        public async Task DeleteChannelPlaylists(string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var playlistsRep = uow.GetRepository<PlaylistEntity>();

                var playlists = await this.GetChannelPlaylists(channelId);
                foreach (var playlist in playlists)
                {
                    playlistsRep.DeleteById(playlist.Id);
                }

                await uow.SaveAsync();
            }
        }

        public async Task DeletePlaylist(string playlistId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var playlistsRep = uow.GetRepository<PlaylistEntity>();

                var entity = await playlistsRep.GetAll(e => e.PlaylistId == playlistId).FirstOrDefaultAsync();
                if (entity != null)
                {
                    playlistsRep.DeleteById(entity.Id);
                    await uow.SaveAsync();
                }
            }
        }
    }
}