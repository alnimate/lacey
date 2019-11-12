using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Custom.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Extensions
{
    internal static class RequestExtensions
    {
        public static ClientServiceRequest<TResponse> SetAuthCookies<TResponse>(
            this ClientServiceRequest<TResponse> request,
            AuthCookies authCookies)
        {
            return request
                .AddConnection("keep-alive")
                .AddAccept("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8")
                .AddAcceptLanguage("en-US,en;q=0.8")
                .AddCookies(authCookies);
        }
    }
}