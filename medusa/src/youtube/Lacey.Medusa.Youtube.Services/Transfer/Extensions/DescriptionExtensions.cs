using System;
using System.Collections.Generic;
using Lacey.Medusa.Youtube.Api.Base;

namespace Lacey.Medusa.Youtube.Services.Transfer.Extensions
{
    internal static class DescriptionExtensions
    {
        public static string Replace(
            this string description,
            Dictionary<string, string> replacements)
        {
            if (string.IsNullOrEmpty(description)
                || replacements == null)
            {
                return description;
            }

            foreach (var replacement in replacements)
            {
                description = description
                    .Replace(replacement.Key, replacement.Value, StringComparison.InvariantCultureIgnoreCase);
            }

            return description;
        }

        public static Video ReplaceDescription(
            this Video video,
            Dictionary<string, string> replacements)
        {
            if (video?.Snippet == null)
            {
                return video;
            }

            video.Snippet.Title = video.Snippet.Title.Replace(replacements);
            video.Snippet.Description = video.Snippet.Description.Replace(replacements);

            return video;
        }
    }
}