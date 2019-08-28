using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Api.Core.Custom.Extensions;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class CookiesInterceptor : IHttpExecuteInterceptor
    {
        private readonly object cookies;

        public CookiesInterceptor(object cookies)
        {
            this.cookies = cookies;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (this.cookies != null)
            {
                request.Headers.Add("Cookie", this.cookies.GetCookiesString());
            }

            return Task.FromResult(0);
        }
    }
}