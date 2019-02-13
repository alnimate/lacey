using System.Text.RegularExpressions;

namespace Lacey.Medusa.Boost.Services.Extensions
{
    internal static class StringExtensions
    {
        public static string RemoveEmoji(
            this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            return Regex.Replace(text, @"[^\u0000-\u007F]+", string.Empty);
        }
    }
}