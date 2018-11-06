using System.Collections.Generic;
using Lacey.Medusa.Common.DataAnnotations.Attributes.Data;

namespace Lacey.Medusa.Youtube.Services.Database.Models.Videos.Lists
{
    public sealed class VideosListRequest
    {
        public VideosListRequest(IEnumerable<int> channels)
        {
            this.Channels = channels;
        }

        [IntIds]
        public IEnumerable<int> Channels { get; }
    }
}