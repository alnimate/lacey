namespace Lacey.Medusa.Youtube.Common.Models.Common
{
    public sealed class YoutubeThumbnail
    {
        public YoutubeThumbnail(string url)
        {
            Url = url;
        }

        public string Url { get; }
    }
}