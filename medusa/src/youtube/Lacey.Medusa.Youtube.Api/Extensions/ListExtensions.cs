using System.Collections.Generic;

namespace Lacey.Medusa.Youtube.Api.Extensions
{
    public static class ListExtensions
    {
        public static string AsListParam(
            this string[] args)
        {
            return string.Join(',', args);
        }

        public static string AsListParam(
            this IReadOnlyList<string> args)
        {
            return string.Join(',', args);
        }
    }
}