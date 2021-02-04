using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class SecFetchDestInterceptor : IHttpExecuteInterceptor
    {
        private readonly string _value;

        public SecFetchDestInterceptor(string value)
        {
            _value = value;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Remove("Sec-Fetch-Dest");
            request.Headers.Add("Sec-Fetch-Dest", _value);

            return Task.CompletedTask;
        }
    }
}