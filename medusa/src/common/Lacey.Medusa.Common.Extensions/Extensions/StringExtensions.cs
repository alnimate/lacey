using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lacey.Medusa.Common.Extensions.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceWholeWord(
            this string original, 
            string wordToFind, 
            string replacement, 
            RegexOptions regexOptions = RegexOptions.IgnoreCase | RegexOptions.Multiline)
        {
            var pattern = $@"\b{wordToFind}\b";
            return Regex.Replace(original, pattern, replacement, regexOptions);
        }

        public static string ReplaceWholeWords(
            this string description,
            Dictionary<string, string> replacements)
        {
            if (string.IsNullOrEmpty(description)
                || replacements == null)
            {
                return description;
            }

            foreach (var replacement in replacements)
            {
                description = description
                    .ReplaceWholeWord(replacement.Key, replacement.Value);
            }

            return description;
        }
    }
}