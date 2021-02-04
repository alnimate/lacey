using System.Net.Http;
using System.Threading.Tasks;
using Lacey.Alexa.Common.Shodan.Models.Login;
using Lacey.Medusa.Common.Api.Custom.Extensions;

namespace Lacey.Alexa.Common.Shodan.Extensions
{
    internal static class ResponseExtensions
    {
        public static async Task<LoginGetResponseModel> ToLoginGet(this HttpResponseMessage response)
        {
            var result = await (await response.Content.ReadAsStringAsync()).ToLoginGet();
            result.CfdUid = response.GetCookie("__cfduid");
            result.Session = response.GetCookie("session");

            return result;
        }
    }
}