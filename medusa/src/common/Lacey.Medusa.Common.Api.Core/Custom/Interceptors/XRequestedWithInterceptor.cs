using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class XRequestedWithInterceptor : IHttpExecuteInterceptor
    {
        private readonly string xRequestedWith;

        public XRequestedWithInterceptor(string xRequestedWith)
        {
            this.xRequestedWith = xRequestedWith;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Remove("X-Requested-With");
            request.Headers.Add("X-Requested-With", this.xRequestedWith);

            return Task.FromResult(0);
        }
    }
}