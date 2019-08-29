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
            var header = response.Headers.GetValues("Set-Cookie").FirstOrDefault();

            if (string.IsNullOrEmpty(header))
            {
                return string.Empty;
            }

            return header.GetCookie(cookieName);
        }
    }
}