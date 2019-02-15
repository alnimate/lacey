using System.Linq;
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

        public static string[] DivideBySentences(
            this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string[]{};
            }

            return Regex.Split(text, @"(?<=[\.!\?])\s+");
        }

        public static string GetFirstSentence(
            this string text)
        {            
            var sentences = text.DivideBySentences();

            return sentences.FirstOrDefault();
        }
    }
}