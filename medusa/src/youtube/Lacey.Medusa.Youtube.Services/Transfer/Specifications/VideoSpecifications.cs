using System.Linq;
using Lacey.Medusa.Youtube.Domain.Entities;

namespace Lacey.Medusa.Youtube.Services.Transfer.Specifications
{
    internal static class VideoSpecifications
    {
        internal static IQueryable<VideoEntity> GetByTransfer(
            this IQueryable<VideoEntity> query,
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
    }
}