using System;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Services.Specifications;
using Lacey.Medusa.Youtube.Domain.Entities;
using Lacey.Medusa.Youtube.Services.Database.Models.Videos.Overviews;
using Lacey.Medusa.Youtube.Services.Database.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Lacey.Medusa.Youtube.Services.Database.Mappers
{
    internal static class VideosMapper
    {
        internal static async Task<VideoOverviews> MapToVideoOverviews(
            VideoOverviewsRequest request,
            IQueryable<ChannelEntity> channels,
            IQueryable<VideoEntity> videos)
        {
            // Build SQL query
            var query1 = from v in videos.GetByChannels(request.Channels)
                            .GetByDescription(request.Description)
                        join c in channels on v.ChannelId equals c.Id
                        select new
                                   {
                                       v.Id,
                                       v.VideoId,
                                       v.Description,
                                       v.PublishedAt,
                                       Channel = c
                                   };

            var query = from q1 in query1
                        select new VideoOverviewQuery
                        {
                            Id = q1.Id,
                            VideoId = q1.VideoId,
                            Description = q1.Description,
                            PublishedAt = q1.PublishedAt,
                            Channel = q1.Channel,
                            RecordsCount = query1.Count()
                        };

            var sortBy = new SortFields<VideoOverviewQuery>
            {
                { "publishedAt", e => e.PublishedAt },                     
                { "channel", e => e.Channel.Name }                     
            };
            query = query
                    .SortBy(request, sortBy)
                    .GetPage(request);

            // Run SQL query
            var entities = await query.ToArrayAsync();

            // Map entities to models
            var overviews = entities.Select(e => new VideoOverview(e.Id, 
                                            e.VideoId, 
                                            e.Description, 
                                            e.PublishedAt, 
                                            e.Channel.Id));

            return new VideoOverviews(
                            request,
                            entities.Any() ? entities.First().RecordsCount : 0,
                            overviews);
        }

        private class VideoOverviewQuery
        {
            public int Id { get; set; }

            public string VideoId { get; set; }

            public string Description { get; set; }

            public DateTime PublishedAt { get; set; }

            public ChannelEntity Channel { get; set; }

            public int RecordsCount { get; set; }
        }
    }
}