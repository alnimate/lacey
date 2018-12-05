using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Domain.Entities;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services
{
    public interface IPlaylistsService
    {
        Task<IEnumerable<PlaylistEntity>> GetPlaylists(string originalChannelId, string channelId);

        Task<int> Add(string originalChannelId, string channelId, Playlist playlist);
    }
}