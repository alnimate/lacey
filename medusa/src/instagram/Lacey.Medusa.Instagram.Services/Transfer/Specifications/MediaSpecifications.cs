using System.Linq;
using Lacey.Medusa.Instagram.Domain.Entities;

namespace Lacey.Medusa.Instagram.Services.Transfer.Specifications
{
    internal static class MediaSpecifications
    {
        internal static IQueryable<MediaEntity> GetByTransfer(
            this IQueryable<MediaEntity> query,
            string originalChannelId,
            string channelId)
        {
            if (string.IsNullOrEmpty(originalChannelId) ||
                string.IsNullOrEmpty(channelId))
            {
                return query;
            }

            query = query.Where(e => e.Channel.OriginalChannelId == originalChannelId &&
                                     e.Channel.ChannelId == channelId);

            return query;
        }

        internal static IQueryable<MediaEntity> GetByChannelId(
            this IQueryable<MediaEntity> query,
            string channelId)
        {
            if (string.IsNullOrEmpty(channelId))
            {
                return query;
            }

            query = query.Where(e => e.Channel.ChannelId == channelId);

            return query;
        }

        internal static IQueryable<MediaEntity> GetByMediaId(
            this IQueryable<MediaEntity> query,
            string mediaId)
        {
            if (string.IsNullOrEmpty(mediaId))
            {
                return query;
            }

            query = query.Where(e => e.MediaId == mediaId);

            return query;
        }
    }
}