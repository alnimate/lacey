using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using Lacey.Alexa.Common.Shodan.Models.Login;
using Lacey.Medusa.Common.Api.Custom.Extensions;

namespace Lacey.Alexa.Common.Shodan.Extensions
{
    internal static class ResponseExtensions
    {
        public static async Task<LoginGetResponseModel> ToLoginGet(this HttpResponseMessage response)
        {
            var html = await response.Content.ReadAsStringAsync();
            var result = new LoginGetResponseModel();
            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(html);

            result.GrantType = document.All.FirstOrDefault(e =>
                    e.HasAttribute("name") && e.GetAttribute("name") == "grant_type")
                ?.GetAttribute("value");
            result.Continue = document.All.FirstOrDefault(e =>
                    e.HasAttribute("name") && e.GetAttribute("name") == "continue")
                ?.GetAttribute("value");
            result.CsrfToken = document.All.FirstOrDefault(e =>
                    e.HasAttribute("name") && e.GetAttribute("name") == "csrf_token")
                ?.GetAttribute("value");
            result.CfdUid = response.GetCookie("__cfduid");
            result.Session = response.GetCookie("session");

            return result;
        }
    }
}