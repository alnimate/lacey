using System.Text;
using Lacey.Medusa.Youtube.Api.Base;

namespace Lacey.Medusa.Boost.Services.Extensions
{
    internal static class VideoExtensions
    {
        private const string YoutubeVideoUrl = "https://www.youtube.com/watch?v=";

        public static string GetBoostText(
            this Video video)
        {
            if (video == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"*{video.Snippet.Title}*");
            sb.AppendLine(video.GetYoutubeUrl());
            sb.AppendLine(video.Snippet.Description);

            return sb.ToString();
        }

        public static string GetYoutubeUrl(
            this Video video)
        {
            if (video == null)
            {
                return string.Empty;
            }

            return $"{YoutubeVideoUrl}{video.Id}";
        }

        public static string GetYoutubeUrl(
            this SearchResult video)
        {
            if (video == null ||
                string.IsNullOrEmpty(video.Id?.VideoId))
            {
                return string.Empty;
            }

            return $"{YoutubeVideoUrl}{video.Id.VideoId}";
        }
    }
}