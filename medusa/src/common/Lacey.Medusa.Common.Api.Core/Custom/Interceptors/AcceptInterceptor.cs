using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class AcceptInterceptor : IHttpExecuteInterceptor
    {
        private readonly string accept;

        public AcceptInterceptor(string accept)
        {
            this.accept = accept;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Remove("Accept");
            request.Headers.Add("Accept", this.accept);

            return Task.FromResult(0);
        }
    }
}