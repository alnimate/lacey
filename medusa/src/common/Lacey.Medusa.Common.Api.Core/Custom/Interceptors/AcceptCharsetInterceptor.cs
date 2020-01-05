using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class AcceptCharsetInterceptor : IHttpExecuteInterceptor
    {
        private readonly string acceptCharset;

        public AcceptCharsetInterceptor(string acceptCharset)
        {
            this.acceptCharset = acceptCharset;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.AcceptCharset.Clear();
            request.Headers.AcceptCharset.Add(new StringWithQualityHeaderValue(this.acceptCharset));

            return Task.FromResult(0);
        }
    }
}