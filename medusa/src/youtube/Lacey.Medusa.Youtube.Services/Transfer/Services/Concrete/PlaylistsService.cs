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
    public sealed class PlaylistsService : UnitOfWorkService, IPlaylistsService
    {
        private readonly IMapper mapper;

        public PlaylistsService(
            IUnitOfWorkFactory unitOfWorkFactory, 
            IMapper mapper) : base(unitOfWorkFactory)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PlaylistEntity>> GetPlaylists(string originalChannelId, string channelId)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var channelsRep = uow.GetRepository<ChannelEntity>();
                var playlistsRep = uow.GetRepository<PlaylistEntity>();

                return await PlaylistsMapper.MapToPlaylists(
                    channelsRep.GetAll(),
                    playlistsRep.GetAll(),
                    originalChannelId,
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
    }
}