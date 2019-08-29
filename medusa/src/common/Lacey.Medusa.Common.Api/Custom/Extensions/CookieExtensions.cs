using System.Text.RegularExpressions;

namespace Lacey.Medusa.Common.Api.Custom.Extensions
{
    public static class CookieExtensions
    {
        public static string GetCookie(this string header, string cookieName)
        {
            var m = Regex.Match(header, $"{cookieName}=(?<value>.*?);");

            if (m.Groups.Count < 2)
            {
                return null;
            }

            return m.Groups[1].Value;
        }
    }
}