using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class UserAgentInterceptor : IHttpExecuteInterceptor
    {
        private readonly string userAgent;

        public UserAgentInterceptor(string userAgent)
        {
            this.userAgent = userAgent;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Remove("User-Agent");
            if (!string.IsNullOrEmpty(this.userAgent))
            {
                request.Headers.Add("User-Agent", this.userAgent);
            }

            return Task.FromResult(0);
        }
    }
}