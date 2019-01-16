namespace Lacey.Medusa.Youtube.Services.Transfer.Models.Copyright
{
    public sealed class CopyrightNoticeClaim
    {
        public CopyrightNoticeClaim(
            ClaimContent content, 
            ClaimClaimants claimants, 
            ClaimPolicy policy)
        {
            Content = content;
            Claimants = claimants;
            Policy = policy;
        }

        public ClaimContent Content { get; private set; }

        public ClaimClaimants Claimants { get; private set; }

        public ClaimPolicy Policy { get; private set; }
    }
}