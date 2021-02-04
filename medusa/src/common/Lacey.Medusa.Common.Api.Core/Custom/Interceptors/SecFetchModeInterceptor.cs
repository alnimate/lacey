using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class SecFetchModeInterceptor : IHttpExecuteInterceptor
    {
        private readonly string _value;

        public SecFetchModeInterceptor(string value)
        {
            _value = value;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Remove("Sec-Fetch-Mode");
            request.Headers.Add("Sec-Fetch-Mode", _value);

            return Task.CompletedTask;
        }
    }
}