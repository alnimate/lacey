namespace Lacey.Medusa.Youtube.Common.Models.Videos
{
    public sealed class YoutubeVideoFile
    {
        public YoutubeVideoFile(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }
    }
}