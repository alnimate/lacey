using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class AcceptEncodingInterceptor : IHttpExecuteInterceptor
    {
        private readonly string acceptEncoding;

        public AcceptEncodingInterceptor(string acceptEncoding)
        {
            this.acceptEncoding = acceptEncoding;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.AcceptEncoding.Clear();
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue(this.acceptEncoding));

            return Task.FromResult(0);
        }
    }
}