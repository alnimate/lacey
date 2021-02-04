using System.Linq;
using System.Net.Http;

namespace Lacey.Medusa.Common.Api.Custom.Extensions
{
    public static class ResponseExtensions
    {
        public static string GetCookie(
            this HttpResponseMessage response,
            string cookieName)
        {
            var headers = response.Headers.GetValues("Set-Cookie").ToArray();

            if (!headers.Any())
            {
                return string.Empty;
            }

            foreach (var header in headers)
            {
                var cookie = header.GetCookie(cookieName);
                if (!string.IsNullOrEmpty(cookie))
                {
                    return cookie;
                }
            }

            return string.Empty;
        }
    }
}