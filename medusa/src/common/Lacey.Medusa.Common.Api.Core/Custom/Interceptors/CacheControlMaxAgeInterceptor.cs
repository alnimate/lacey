using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class CacheControlMaxAgeInterceptor : IHttpExecuteInterceptor
    {
        private readonly TimeSpan? _value;

        public CacheControlMaxAgeInterceptor(TimeSpan? value)
        {
            this._value = value;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.CacheControl == null)
            {
                request.Headers.CacheControl = new CacheControlHeaderValue();
            }

            request.Headers.CacheControl.MaxAge = _value;

            return Task.CompletedTask;
        }
    }
}