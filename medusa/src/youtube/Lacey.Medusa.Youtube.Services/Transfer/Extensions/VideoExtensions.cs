using System;
using System.Collections.Generic;
using Lacey.Medusa.Common.Extensions.Extensions;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Domain.Entities;

namespace Lacey.Medusa.Youtube.Services.Transfer.Extensions
{
    internal static class VideoExtensions
    {
        public static Video ReplaceDescription(
            this Video video,
            Dictionary<string, string> replacements)
        {
            if (video?.Snippet == null)
            {
                return video;
            }

            video.Snippet.Title = video.Snippet.Title.ReplaceWholeWords(replacements);
            video.Snippet.Description = video.Snippet.Description.ReplaceWholeWords(replacements);

            return video;
        }

        public static bool IsObsoleted(
            this Video video,
            int threshold)
        {
            if (video?.Snippet?.PublishedAt == null)
            {
                return true;
            }

            return (DateTime.UtcNow - video.Snippet.PublishedAt.Value).TotalDays > threshold;
        }

        public static bool IsObsoleted(
            this PlaylistItem video,
            int threshold)
        {
            if (video?.Snippet?.PublishedAt == null)
            {
                return true;
            }

            return (DateTime.UtcNow - video.Snippet.PublishedAt.Value).TotalDays > threshold;
        }

        public static bool IsObsoleted(
            this VideoEntity video,
            int threshold)
        {
            if (video == null)
            {
                return true;
            }

            return (DateTime.UtcNow - video.CreatedAt).TotalDays > threshold;
        }
    }
}