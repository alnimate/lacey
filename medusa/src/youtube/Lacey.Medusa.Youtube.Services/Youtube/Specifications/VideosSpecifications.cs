using System.Collections.Generic;
using System.Linq;
using Lacey.Medusa.Youtube.Domain.Entities;

namespace Lacey.Medusa.Youtube.Services.Youtube.Specifications
{
    internal static class VideosSpecifications
    {
        internal static IQueryable<VideoEntity> GetByChannels(
            this IQueryable<VideoEntity> query,
            IEnumerable<int> channels)
        {
            if (channels == null)
            {
                return query;
            }

            var enumerable = channels as int[] ?? channels.ToArray();
            if (enumerable.Any())
            {
                query = query.Where(e => enumerable.Contains(e.ChannelId));
            }

            return query;
        }

        internal static IQueryable<VideoEntity> GetByDescription(
            this IQueryable<VideoEntity> query,
            string description)
        {

            if (!string.IsNullOrWhiteSpace(description))
            {
                var desc = description.Trim().ToLower();
                query = query.Where(e => e.Description.Trim().ToLower().Contains(desc));
            }
            return query;
        }
    }
}