using System.ComponentModel.DataAnnotations;
using Lacey.Medusa.Common.Services.Models.Overviews;

namespace Lacey.Medusa.Youtube.Services.Management.Models.Channels.Overviews
{
    public sealed class ChannelOverviewsRequest : OverviewsRequestModel
    {
        public ChannelOverviewsRequest(
            string title,
            string sortBy, 
            bool desc, 
            int? pageSize, 
            int? pageNumber)
            : base(sortBy, desc, pageSize, pageNumber)
        {
            this.Title = title;
        }

        [Required]
        [MaxLength(30)]
        public string Title { get; }
    }
}