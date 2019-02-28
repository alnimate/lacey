using System.Linq;
using System.Text;
using Lacey.Medusa.Boost.Services.Const;
using Lacey.Medusa.Youtube.Api.Base;

namespace Lacey.Medusa.Boost.Services.Extensions
{
    internal static class VideoExtensions
    {
        public static string GetYoutubeBoostText(
            this Video video)
        {
            if (video == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"{video.Snippet.Title}");
            sb.AppendLine(video.GetYoutubeShortUrl());
            sb.AppendLine(video.Snippet.Description.GetFirstSentence());

            return sb.ToString();
        }

        public static string GetInstagramBoostText(
            this Video video)
        {
            if (video == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"    {video.GetYoutubeShortUrl()}    ");
            sb.AppendLine($"❤️{video.Snippet.Title} ");
            sb.AppendLine($"❤️{video.Snippet.Description.GetFirstSentence()}");

            return sb.ToString();
        }

        public static string GetYoutubeShortUrl(
            this Video video)
        {
            if (video == null)
            {
                return string.Empty;
            }

            return $"{YoutubeConst.YoutubeShortVideoUrl}{video.Id}";
        }

        public static string GetYoutubeUrl(
            this Video video)
        {
            if (video == null)
            {
                return string.Empty;
            }

            return $"{YoutubeConst.YoutubeVideoUrl}{video.Id}";
        }

        public static string GetYoutubeUrl(
            this SearchResult video)
        {
            if (video == null ||
                string.IsNullOrEmpty(video.Id?.VideoId))
            {
                return string.Empty;
            }

            return $"{YoutubeConst.YoutubeVideoUrl}{video.Id.VideoId}";
        }

        public static string GetYoutubeQuery(
            this Video video,
            string[] excludes)
        {
            var tags = video?.Snippet?.Tags;
            if (tags == null)
            {
                return string.Empty;
            }

            if (excludes != null && excludes.Any())
            {
                tags = tags.RemoveSimilar(excludes.ToArray());
            }

            return tags.ToYoutubeQuery();
        }

        public static string GetInstagramQuery(
            this Video video,
            string[] excludes)
        {
            var tags = video?.Snippet?.Tags;
            if (tags == null)
            {
                return string.Empty;
            }

            if (excludes != null && excludes.Any())
            {
                tags = tags.RemoveSimilar(excludes.ToArray());
            }

            return tags.ToInstagramQuery();
        }
    }
}