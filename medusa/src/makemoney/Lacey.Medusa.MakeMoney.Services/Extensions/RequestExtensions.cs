using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Custom.Extensions;

namespace Lacey.Medusa.MakeMoney.Services.Extensions
{
    internal static class RequestExtensions
    {
        public static ClientServiceRequest<TResponse> SetDefault<TResponse>(
            this ClientServiceRequest<TResponse> request)
        {
            request.ClearExecInterceptors();

            var res = request
                .AddUserAgent(string.Empty)
                .AddAcceptEncoding("gzip")
                .AddContentType("application/x-www-form-urlencoded; charset=UTF-8")
                .AddConnection("Keep-Alive");

            return res;
        }
    }
}