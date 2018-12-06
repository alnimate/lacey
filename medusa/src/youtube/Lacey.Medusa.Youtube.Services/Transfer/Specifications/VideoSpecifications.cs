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

        internal static IQueryable<VideoEntity> GetByChannelId(
            this IQueryable<VideoEntity> query,
            string channelId)
        {
            if (string.IsNullOrEmpty(channelId))
            {
                return query;
            }

            query = query.Where(e => e.Channel.ChannelId == channelId);

            return query;
        }

        internal static IQueryable<VideoEntity> GetByVideoId(
            this IQueryable<VideoEntity> query,
            string videoId)
        {
            if (string.IsNullOrEmpty(videoId))
            {
                return query;
            }

            query = query.Where(e => e.VideoId == videoId);

            return query;
        }
    }
}