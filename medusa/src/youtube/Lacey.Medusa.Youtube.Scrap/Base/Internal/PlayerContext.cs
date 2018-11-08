namespace Lacey.Medusa.Youtube.Scrap.Base.Internal
{
    internal class PlayerContext
    {
        public string SourceUrl { get; }

        public string Sts { get; }

        public PlayerContext(string sourceUrl, string sts)
        {
            SourceUrl = sourceUrl;
            Sts = sts;
        }
    }
}