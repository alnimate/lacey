namespace Lacey.Medusa.Youtube.Scrap.Base.Internal
{
    public class PlayerContext
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