namespace Lacey.Medusa.Youtube.Services.Transfer.Models.Copyright
{
    public sealed class ClaimPolicy
    {
        public ClaimPolicy(string policy)
        {
            Policy = policy;
        }

        public string Policy { get; private set; }
    }
}