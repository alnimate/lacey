using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Domain.Entities;
using Lacey.Medusa.Youtube.Services.Transfer.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Lacey.Medusa.Youtube.Services.Transfer.Mappers
{
    internal static class PlaylistsMapper
    {
        internal static async Task<IEnumerable<PlaylistEntity>> MapToPlaylists(
            IQueryable<ChannelEntity> channels,
            IQueryable<PlaylistEntity> playlists,
            string originalChannelId,
            string channelId)
        {
            var query = from p in playlists.GetByTransfer(originalChannelId, channelId)
                join c in channels on p.ChannelId equals c.Id
                select p;

            return await query.ToArrayAsync();
        }
    }
}