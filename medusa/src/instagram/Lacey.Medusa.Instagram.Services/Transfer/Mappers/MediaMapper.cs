using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Instagram.Domain.Entities;
using Lacey.Medusa.Instagram.Services.Transfer.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Lacey.Medusa.Instagram.Services.Transfer.Mappers
{
    internal static class MediaMapper
    {
        internal static async Task<IReadOnlyList<MediaEntity>> MapToTransferMedias(
            IQueryable<ChannelEntity> channels,
            IQueryable<MediaEntity> medias,
            string originalChannelId,
            string channelId)
        {
            var query = from v in medias.GetByTransfer(originalChannelId, channelId)
                        join c in channels on v.ChannelId equals c.Id
                        select v;

            return await query.ToListAsync();
        }

        internal static async Task<IReadOnlyList<MediaEntity>> MapToChannelMedias(
            IQueryable<ChannelEntity> channels,
            IQueryable<MediaEntity> medias,
            string channelId)
        {
            var query = from v in medias.GetByChannelId(channelId)
                        join c in channels on v.ChannelId equals c.Id
                        select v;

            return await query.ToListAsync();
        }

        internal static async Task<MediaEntity> MapToMedia(
            IQueryable<MediaEntity> medias,
            string mediaId)
        {
            var query = from p in medias.GetByMediaId(mediaId)
                select p;

            return await query.FirstOrDefaultAsync();
        }
    }
}