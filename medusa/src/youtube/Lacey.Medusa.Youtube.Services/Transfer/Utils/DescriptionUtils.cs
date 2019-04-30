using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Lacey.Medusa.Common.Extensions.Extensions;

namespace Lacey.Medusa.Youtube.Services.Transfer.Utils
{
    public static class DescriptionUtils
    {
        public static string TransformDescription(
            string channleId,
            string description,
            Dictionary<string, string> replacements)
        {
            var templateFile = Path.Combine(
                Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                "templates",
                $"{channleId}.tmpl");

            if (!File.Exists(templateFile))
            {
                return description.ReplaceWholeWords(replacements);
            }

            var template = File.ReadAllText(templateFile);

            return string.Format(template, description.ReplaceWholeWords(replacements));
        }
    }
}