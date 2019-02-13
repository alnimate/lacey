using System;
using System.Collections.Generic;
using System.Linq;

namespace Lacey.Medusa.Boost.Services.Extensions
{
    internal static class QueryExtensions
    {
        public static string ToQuery(
            this string[] tags)
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
    }
}