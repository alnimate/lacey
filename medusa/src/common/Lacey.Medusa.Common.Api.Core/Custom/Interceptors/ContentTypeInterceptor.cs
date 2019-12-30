using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class ContentTypeInterceptor : IHttpExecuteInterceptor
    {
        private readonly string contentType;

        public ContentTypeInterceptor(string contentType)
        {
            this.contentType = contentType;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Content.Headers.Remove("Content-Type");
            request.Content.Headers.Add("Content-Type", this.contentType);

            return Task.FromResult(0);

        }
    }
}