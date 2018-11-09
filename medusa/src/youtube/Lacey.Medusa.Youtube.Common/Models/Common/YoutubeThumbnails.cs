namespace Lacey.Medusa.Youtube.Common.Models.Common
{
    public sealed class YoutubeThumbnails
    {
        public YoutubeThumbnails(
            YoutubeThumbnail @default, 
            YoutubeThumbnail medium, 
            YoutubeThumbnail high, 
            YoutubeThumbnail standard, 
            YoutubeThumbnail max)
        {
            Default = @default;
            Medium = medium;
            High = high;
            Standard = standard;
            Max = max;
        }

        public YoutubeThumbnail Default { get; }

        public YoutubeThumbnail Medium { get; }

        public YoutubeThumbnail High { get; }

        public YoutubeThumbnail Standard { get; }

        public YoutubeThumbnail Max { get; }
    }
}