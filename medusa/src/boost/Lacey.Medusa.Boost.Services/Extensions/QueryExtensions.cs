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

            return string.Join("|", tags.Take(3));
        }
    }
}