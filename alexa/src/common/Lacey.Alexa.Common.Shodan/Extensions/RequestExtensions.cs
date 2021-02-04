using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Custom.Extensions;

namespace Lacey.Alexa.Common.Shodan.Extensions
{
    internal static class RequestExtensions
    {
        public static ClientServiceRequest<TResponse> SetDefault<TResponse>(
            this ClientServiceRequest<TResponse> request)
        {
            request.ClearExecInterceptors();

            var res = request
                .AddConnection("keep-alive")
                .AddUpgradeInsecureRequests("1")
                .AddUserAgent("Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.104 Safari/537.36")
                .AddAccept("text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9")
                .AddSecFetchSite("none")
                .AddSecFetchMode("navigate")
                .AddSecFetchUser("?1")
                .AddSecFetchDest("document")
                .AddAcceptEncoding("gzip, deflate, br")
                .AddAcceptLanguage("en-US,en;q=0.9");

            return res;
        }
    }
}