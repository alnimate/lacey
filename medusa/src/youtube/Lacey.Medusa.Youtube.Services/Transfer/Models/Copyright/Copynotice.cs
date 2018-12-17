using System.Collections.Generic;

namespace Lacey.Medusa.Youtube.Services.Transfer.Models.Copyright
{
    public sealed class Copynotice
    {
        public Copynotice(
            string videoId, 
            IReadOnlyList<CopynoyiceClaim> claims)
        {
            VideoId = videoId;
            Claims = claims;
        }

        public string VideoId { get; private set; }

        public IReadOnlyList<CopynoyiceClaim> Claims { get; private set; }
    }
}