using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class AcceptLanguageInterceptor : IHttpExecuteInterceptor
    {
        private readonly string acceptLanguage;

        public AcceptLanguageInterceptor(string acceptLanguage)
        {
            this.acceptLanguage = acceptLanguage;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Remove("Accept-Language");
            request.Headers.Add("Accept-Language", this.acceptLanguage);

            return Task.FromResult(0);
        }
    }
}