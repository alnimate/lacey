namespace Lacey.Medusa.Youtube.Common.Models.About
{
    public sealed class YoutubeAbout
    {
        public YoutubeAbout(string description)
        {
            Description = description;
        }

        public string Description { get; }
    }
}