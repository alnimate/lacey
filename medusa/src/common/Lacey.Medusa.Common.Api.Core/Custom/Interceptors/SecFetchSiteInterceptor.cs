using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class SecFetchSiteInterceptor : IHttpExecuteInterceptor
    {
        private readonly string _value;

        public SecFetchSiteInterceptor(string value)
        {
            _value = value;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Remove("Sec-Fetch-Site");
            request.Headers.Add("Sec-Fetch-Site", _value);

            return Task.CompletedTask;
        }
    }
}