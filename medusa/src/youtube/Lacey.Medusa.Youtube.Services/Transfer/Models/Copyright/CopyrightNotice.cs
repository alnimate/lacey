using System.Collections.Generic;

namespace Lacey.Medusa.Youtube.Services.Transfer.Models.Copyright
{
    public sealed class CopyrightNotice
    {
        public CopyrightNotice(
            string videoId, 
            IReadOnlyList<CopyrightNoticeClaim> claims)
        {
            VideoId = videoId;
            Claims = claims;
        }

        public string VideoId { get; private set; }

        public IReadOnlyList<CopyrightNoticeClaim> Claims { get; private set; }
    }
}