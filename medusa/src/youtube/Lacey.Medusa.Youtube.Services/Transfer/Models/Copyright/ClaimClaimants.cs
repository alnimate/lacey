using System.Collections.Generic;

namespace Lacey.Medusa.Youtube.Services.Transfer.Models.Copyright
{
    public sealed class ClaimClaimants
    {
        public ClaimClaimants(
            IReadOnlyList<string> claimants, 
            string onBehalfOf)
        {
            Claimants = claimants;
            OnBehalfOf = onBehalfOf;
        }

        public IReadOnlyList<string> Claimants { get; private set; }

        public string OnBehalfOf { get; private set; }
    }
}