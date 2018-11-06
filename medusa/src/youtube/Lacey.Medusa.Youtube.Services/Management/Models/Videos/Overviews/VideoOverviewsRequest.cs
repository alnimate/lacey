using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lacey.Medusa.Common.DataAnnotations.Attributes.Data;
using Lacey.Medusa.Common.Services.Models.Overviews;

namespace Lacey.Medusa.Youtube.Services.Management.Models.Videos.Overviews
{
    public sealed class VideoOverviewsRequest : OverviewsRequestModel
    {
        public VideoOverviewsRequest(
            IEnumerable<int> channels, 
            string description,
            string sortBy, 
            bool desc, 
            int? pageSize, 
            int? pageNumber)
            : base(sortBy, desc, pageSize, pageNumber)
        {
            Channels = channels;
            Description = description;
        }

        [IntIds]
        public IEnumerable<int> Channels { get; }

        [Required]
        [MaxLength(100)]
        public string Description { get; }
    }
}