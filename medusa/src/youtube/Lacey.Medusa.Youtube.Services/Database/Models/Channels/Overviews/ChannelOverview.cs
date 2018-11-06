using System.ComponentModel.DataAnnotations;
using Lacey.Medusa.Common.DataAnnotations.Attributes.Data;

namespace Lacey.Medusa.Youtube.Services.Database.Models.Channels.Overviews
{
    public sealed class ChannelOverview
    {
        public ChannelOverview(
            int id,
            string channelId,
            string title)
        {
            this.Id = id;
            this.ChannelId = channelId;
            this.Title = title;
        }

        [IntId]
        public int Id { get; }

        [Required]
        [MaxLength(30)]
        public string ChannelId { get; }

        [Required]
        [MaxLength(30)]
        public string Title { get; }
    }
}