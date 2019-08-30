using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class ConnectionInterceptor : IHttpExecuteInterceptor
    {
        private readonly string connection;

        public ConnectionInterceptor(string connection)
        {
            this.connection = connection;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Remove("Connection");
            request.Headers.Add("Connection", this.connection);

            return Task.FromResult(0);
        }
    }
}