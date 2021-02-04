using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Medusa.Common.Api.Core.Custom.Interceptors
{
    public sealed class AcceptEncodingsInterceptor : IHttpExecuteInterceptor
    {
        private readonly string[] _values;

        public AcceptEncodingsInterceptor(params string[] values)
        {
            _values = values;
        }

        public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.AcceptEncoding.Clear();
            foreach (var value in _values)
            {
                request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue(value));
            }

            return Task.CompletedTask;
        }
    }
}