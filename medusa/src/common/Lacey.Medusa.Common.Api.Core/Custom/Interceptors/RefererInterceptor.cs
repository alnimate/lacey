using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class RefererInterceptor : IHttpExecuteInterceptor
    {
        private readonly string referer;

        public RefererInterceptor(string referer)
        {
            this.referer = referer;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Remove("Referer");
            request.Headers.Add("Referer", this.referer);

            return Task.FromResult(0);
        }
    }
}