using System.Text.RegularExpressions;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.SignIn;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Extensions
{
    internal static class HtmlExtensions
    {
        public static SignInResponseModel GetSignInResponse(this string html)
        {
            var bvb = string.Empty;

            var match = Regex.Match(html, @".*BVB45629\s*=\s*(\w+)\s*"";\s*document.*", RegexOptions.Multiline);
            if (match.Groups.Count > 1)
            {
                bvb = match.Groups[1].Value;
            }

            return new SignInResponseModel
            {
                Bvb = bvb
            };
        }
    }
}