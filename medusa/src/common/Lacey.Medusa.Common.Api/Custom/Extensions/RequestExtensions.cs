using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Base.Requests;

namespace Lacey.Medusa.Common.Api.Custom.Extensions
{
    public static class RequestExtensions
    {
        public static async Task<HttpResponseMessage> ExecuteUnparsedAsync<TResponse>(
            this ClientServiceRequest<TResponse> serviceRequest)
        {
            using (var request = serviceRequest.CreateRequest())
            {
                return await serviceRequest.Service.HttpClient.SendAsync(request, CancellationToken.None).ConfigureAwait(false);
            }
        }
    }
}