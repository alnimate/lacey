using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class SecFetchUserInterceptor : IHttpExecuteInterceptor
    {
        private readonly string _value;

        public SecFetchUserInterceptor(string value)
        {
            _value = value;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Remove("Sec-Fetch-User");
            request.Headers.Add("Sec-Fetch-User", _value);

            return Task.CompletedTask;
        }
    }
}