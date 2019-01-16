namespace Lacey.Medusa.Youtube.Services.Transfer.Models.Copyright
{
    public sealed class CopyrightNoyiceClaim
    {
        public CopyrightNoyiceClaim(
            ClaimContent content, 
            ClaimClaimnants claimnants, 
            ClaimPolicy policy)
        {
            Content = content;
            Claimnants = claimnants;
            Policy = policy;
        }

        public ClaimContent Content { get; private set; }

        public ClaimClaimnants Claimnants { get; private set; }

        public ClaimPolicy Policy { get; private set; }
    }
}