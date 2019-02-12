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
            foreach (var tag in tags.Take(2))
            {
                var arr = tag.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length > 3)
                {
                    arr = arr.Take(3).ToArray();
                }

                var tagToAdd = string.Join(' ', arr);
                list.Add(tagToAdd);
            }

            return string.Join("|", list);
        }
    }
}