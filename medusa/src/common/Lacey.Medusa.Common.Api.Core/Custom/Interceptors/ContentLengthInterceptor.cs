using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class ContentLengthInterceptor : IHttpExecuteInterceptor
    {
        private readonly int contentLength;

        public ContentLengthInterceptor(int contentLength)
        {
            this.contentLength = contentLength;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Content.Headers.Remove("Content-Length");
            request.Content.Headers.Add("Content-Length", this.contentLength.ToString());

            return Task.FromResult(0);
        }
    }
}