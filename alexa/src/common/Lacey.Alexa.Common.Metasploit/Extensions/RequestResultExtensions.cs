using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lacey.Alexa.Common.Metasploit.Extensions
{
    public static class RequestResultExtensions
    {
        public static string AsColumns(this Dictionary<string, object> result)
        {
            const int firstCol = -10;
            const int largeCol = -50;
            var sb = new StringBuilder();
            foreach (var (key, value) in result)
            {
                var keyCol = $"[{key}]";
                if (value is Dictionary<string, object> objects)
                {
                    sb.AppendLine(keyCol);
                    foreach (var (k, v) in objects)
                    {
                        var kCol = $"[{k}]";
                        sb.AppendLine($"{string.Empty, firstCol}{kCol,-17}{v, largeCol}");
                    }
                    continue;
                }

                if (value is ICollection coll)
                {
                    sb.AppendLine(keyCol);
                    foreach (var e in coll)
                    {
                        sb.AppendLine($"{string.Empty, firstCol}{e, largeCol}");   
                    }
                    continue;
                }

                sb.AppendLine($"{keyCol, firstCol}{value, largeCol}");
            }

            return sb.ToString();
        }
    }
}