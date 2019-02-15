using System;
using System.Collections.Generic;
using System.Linq;

namespace Lacey.Medusa.Boost.Services.Extensions
{
    internal static class QueryExtensions
    {
        public static string ToYoutubeQuery(
            this IList<string> tags)
        {
            if (tags == null)
            {
                return string.Empty;
            }

            var list = new List<string>();
            const int wordsLimit = 3;
            var i = 0;
            foreach (var tag in tags.Take(3))
            {
                var words = tag.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var tagWords = string.Empty;
                foreach (var word in words)
                {
                    tagWords += $"{word} ";
                    i++;
                    if (i >= wordsLimit)
                    {
                        break;
                    }
                }

                list.Add(tagWords.Trim());
                if (i >= wordsLimit)
                {
                    break;
                }
            }

            return string.Join(" ", list);
        }

        public static string ToInstagramQuery(
            this IList<string> tags)
        {
            if (tags == null || !tags.Any())
            {
                return string.Empty;
            }

            var queryTag = string.Empty;
            foreach (var tag in tags)
            {
                var words = tag.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length == 1)
                {
                    queryTag = tag;
                    break;
                }
            }

            if (string.IsNullOrEmpty(queryTag))
            {
                return string.Empty;
            }

            return $"#{queryTag}";
        }
    }
}