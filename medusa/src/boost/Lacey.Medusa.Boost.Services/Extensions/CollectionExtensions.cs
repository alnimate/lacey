using System.Collections.Generic;
using System.Linq;

namespace Lacey.Medusa.Boost.Services.Extensions
{
    internal static class CollectionExtensions
    {
        public static IList<string> RemoveSimilar(
            this IList<string> list,
            string[] similar)
        {
            if (list == null ||
                !list.Any())
            {
                return list;
            }

            if (similar == null ||
                similar.Length == 0)
            {
                return list;
            }

            var result = new List<string>();
            foreach (var item in list)
            {
                if (!similar.Any(r => r.Replace(" ", string.Empty).ToLower()
                    .Contains(item.Replace(" ", string.Empty).ToLower())))
                {
                    result.Add(item);
                }
            }
            
            return result;
        }
    }
}