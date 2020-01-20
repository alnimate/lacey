using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Custom.Extensions;

namespace Lacey.Medusa.Vendor.AdColony.Extensions
{
    internal static class RequestExtensions
    {
        private const string UserAgent = "Mozilla/5.0 (Linux; Android 9; Android SDK built for x86 Build/PSR1.180720.075; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/69.0.3497.100 Mobile Safari/537.36";

        public static ClientServiceRequest<TResponse> SetDefault<TResponse>(
            this ClientServiceRequest<TResponse> request)
        {
            request.ClearExecInterceptors();

            var res = request
                .AddAcceptCharset("UTF-8")
                .AddAcceptEncoding("gzip")
                .AddUserAgent(UserAgent)
                .AddContentType("application/json")
                .AddConnection("Keep-Alive");

            return res;
        }
    }
}