using System.Collections.Generic;

namespace Lacey.Medusa.Boost.Services.Extensions
{
    internal static class CollectionExtensions
    {
        public static IList<T> RemoveAll<T>(
            this IList<T> list,
            T[] removes)
        {
            if (removes == null ||
                removes.Length == 0)
            {
                return list;
            }

            foreach (var remove in removes)
            {
                while (list.Remove(remove))
                {
                }
            }

            return list;
        }
    }
}