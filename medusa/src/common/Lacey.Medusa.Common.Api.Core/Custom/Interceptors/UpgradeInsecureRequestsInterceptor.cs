using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class UpgradeInsecureRequestsInterceptor : IHttpExecuteInterceptor
    {
        private readonly string upgradeInsecureRequests;

        public UpgradeInsecureRequestsInterceptor(string upgradeInsecureRequests)
        {
            this.upgradeInsecureRequests = upgradeInsecureRequests;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Remove("Upgrade-Insecure-Requests");
            request.Headers.Add("Upgrade-Insecure-Requests", this.upgradeInsecureRequests);

            return Task.FromResult(0);
        }
    }
}