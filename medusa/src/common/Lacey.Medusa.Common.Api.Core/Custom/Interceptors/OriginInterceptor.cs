using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class OriginInterceptor : IHttpExecuteInterceptor
    {
        private readonly string origin;

        public OriginInterceptor(string origin)
        {
            this.origin = origin;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Remove("Origin");
            request.Headers.Add("Origin", this.origin);

            return Task.FromResult(0);
        }
    }
}