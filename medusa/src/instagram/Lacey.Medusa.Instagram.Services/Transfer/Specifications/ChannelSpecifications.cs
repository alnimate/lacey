using System.Linq;
using Lacey.Medusa.Instagram.Domain.Entities;

namespace Lacey.Medusa.Instagram.Services.Transfer.Specifications
{
    internal static class ChannelSpecifications
    {
        internal static IQueryable<ChannelEntity> GetByChannelId(
            this IQueryable<ChannelEntity> query,
            string channelId)
        {
            if (string.IsNullOrEmpty(channelId))
            {
                return query;
            }

            query = query.Where(e => e.ChannelId == channelId);

            return query;
        }

        internal static IQueryable<ChannelEntity> GetByOriginalChannelId(
            this IQueryable<ChannelEntity> query,
            string originalChannelId)
        {
            if (string.IsNullOrEmpty(originalChannelId))
            {
                return query;
            }

            query = query.Where(e => e.OriginalChannelId == originalChannelId);

            return query;
        }
    }
}