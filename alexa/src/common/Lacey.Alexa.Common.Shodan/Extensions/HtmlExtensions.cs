using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using Lacey.Alexa.Common.Shodan.Models.Login;

namespace Lacey.Alexa.Common.Shodan.Extensions
{
    internal static class HtmlExtensions
    {
        public static async Task<LoginGetResponseModel> ToLoginGet(this string html)
        {
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

            return result;
        }
    }
}