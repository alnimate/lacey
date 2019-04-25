using System.Collections.Generic;
using Lacey.Medusa.Boost.Services.Utils;

namespace Lacey.Medusa.Boost.Services.Extensions
{
    internal static class NamesExtensions
    {
        public static string GetRandomName(this IReadOnlyList<string> names)
        {
            var name = names[RandomUtils.GetRandom(0, names.Count - 1)];

            return $"{name.Replace(" ", string.Empty).ToLower()}";
        }
    }
}