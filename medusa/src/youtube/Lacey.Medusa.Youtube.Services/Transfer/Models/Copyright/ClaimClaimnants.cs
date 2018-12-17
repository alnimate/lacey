using System.Collections.Generic;

namespace Lacey.Medusa.Youtube.Services.Transfer.Models.Copyright
{
    public sealed class ClaimClaimnants
    {
        public ClaimClaimnants(
            IReadOnlyList<string> claimnants, 
            string onBehalfOf)
        {
            Claimnants = claimnants;
            OnBehalfOf = onBehalfOf;
        }

        public IReadOnlyList<string> Claimnants { get; private set; }

        public string OnBehalfOf { get; private set; }
    }
}