using System;
using System.Text;
using Lacey.Medusa.Youtube.Api.Base;

namespace Lacey.Medusa.Boost.Services.Extensions
{
    internal static class VideoExtensions
    {
        public static string GetBoostText(
            this Video video)
        {
            if (video == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            sb.AppendLine(video.Snippet.Title);
            sb.AppendLine($"https://www.youtube.com/watch?v={video.Id}");
            sb.AppendLine(video.Snippet.Description);

            return sb.ToString();
        }
    }
}