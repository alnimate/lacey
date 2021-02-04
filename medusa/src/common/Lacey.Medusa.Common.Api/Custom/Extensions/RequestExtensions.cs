using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Core.Base;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Api.Core.Custom.Interceptors;

namespace Lacey.Medusa.Common.Api.Custom.Extensions
{
    public static class RequestExtensions
    {
        public static ClientServiceRequest<TResponse> SetSerializer<TResponse>(
            this ClientServiceRequest<TResponse> serviceRequest,
            ISerializer serializer)
        {
            serviceRequest.Service.Serializer = serializer;

            return serviceRequest;
        }

        public static async Task<HttpResponseMessage> ExecuteUnparsedAsync<TResponse>(
            this ClientServiceRequest<TResponse> serviceRequest)
        {
            using (var request = serviceRequest.CreateRequest())
            {
                return await serviceRequest.Service.HttpClient.SendAsync(request, CancellationToken.None).ConfigureAwait(false);
            }
        }

        public static ClientServiceRequest<TResponse> AddExecInterceptor<TResponse>(
            this ClientServiceRequest<TResponse> request,
            IHttpExecuteInterceptor interceptor)
        {
            var existingInterceptor = request.Service.HttpClient.MessageHandler.ExecuteInterceptors
                .FirstOrDefault(i => i.GetType().IsInstanceOfType(interceptor));

            if (existingInterceptor != null)
            {
                request.Service.HttpClient.MessageHandler.RemoveExecuteInterceptor(existingInterceptor);
            }

            request.Service.HttpClient.MessageHandler.AddExecuteInterceptor(interceptor);

            return request;
        }

        public static ClientServiceRequest<TResponse> ClearExecInterceptors<TResponse>(
            this ClientServiceRequest<TResponse> request)
        {
            request.Service.HttpClient.MessageHandler.ClearExecuteInterceptors();

            return request;
        }

        public static ClientServiceRequest<TResponse> AddCookies<TResponse>(
            this ClientServiceRequest<TResponse> request,
            object cookies)
        {
            return request.AddExecInterceptor(new CookiesInterceptor(cookies));
        }

        public static ClientServiceRequest<TResponse> AddUserAgent<TResponse>(
            this ClientServiceRequest<TResponse> request,
            string userAgent)
        {
            return request.AddExecInterceptor(new UserAgentInterceptor(userAgent));
        }

        public static ClientServiceRequest<TResponse> AddConnection<TResponse>(
            this ClientServiceRequest<TResponse> request,
            string connection)
        {
            return request.AddExecInterceptor(new ConnectionInterceptor(connection));
        }

        public static ClientServiceRequest<TResponse> AddAccept<TResponse>(
            this ClientServiceRequest<TResponse> request,
            string accept)
        {
            return request.AddExecInterceptor(new AcceptInterceptor(accept));
        }

        public static ClientServiceRequest<TResponse> AddAcceptEncoding<TResponse>(
            this ClientServiceRequest<TResponse> request,
            string acceptEncoding)
        {
            return request.AddExecInterceptor(new AcceptEncodingInterceptor(acceptEncoding));
        }

        public static ClientServiceRequest<TResponse> AddAcceptEncodings<TResponse>(
            this ClientServiceRequest<TResponse> request,
            params string[] values)
        {
            return request.AddExecInterceptor(new AcceptEncodingsInterceptor(values));
        }

        public static ClientServiceRequest<TResponse> AddAcceptCharset<TResponse>(
            this ClientServiceRequest<TResponse> request,
            string acceptCharset)
        {
            return request.AddExecInterceptor(new AcceptCharsetInterceptor(acceptCharset));
        }

        public static ClientServiceRequest<TResponse> AddOrigin<TResponse>(
            this ClientServiceRequest<TResponse> request,
            string origin)
        {
            return request.AddExecInterceptor(new OriginInterceptor(origin));
        }

        public static ClientServiceRequest<TResponse> AddXRequestedWith<TResponse>(
            this ClientServiceRequest<TResponse> request,
            string xRequestedWith)
        {
            return request.AddExecInterceptor(new XRequestedWithInterceptor(xRequestedWith));
        }

        public static ClientServiceRequest<TResponse> AddReferer<TResponse>(
            this ClientServiceRequest<TResponse> request,
            string referer)
        {
            return request.AddExecInterceptor(new RefererInterceptor(referer));
        }

        public static ClientServiceRequest<TResponse> AddAcceptLanguage<TResponse>(
            this ClientServiceRequest<TResponse> request,
            string acceptLanguage)
        {
            return request.AddExecInterceptor(new AcceptLanguageInterceptor(acceptLanguage));
        }

        public static ClientServiceRequest<TResponse> AddContentLength<TResponse>(
            this ClientServiceRequest<TResponse> request,
            int contentLength)
        {
            return request.AddExecInterceptor(new ContentLengthInterceptor(contentLength));
        }

        public static ClientServiceRequest<TResponse> AddContentType<TResponse>(
            this ClientServiceRequest<TResponse> request,
            string contentType)
        {
            return request.AddExecInterceptor(new ContentTypeInterceptor(contentType));
        }

        public static ClientServiceRequest<TResponse> AddUpgradeInsecureRequests<TResponse>(
            this ClientServiceRequest<TResponse> request,
            string upgradeInsecureRequests)
        {
            return request.AddExecInterceptor(new UpgradeInsecureRequestsInterceptor(upgradeInsecureRequests));
        }

        public static ClientServiceRequest<TResponse> AddSecFetchSite<TResponse>(
            this ClientServiceRequest<TResponse> request,
            string value)
        {
            return request.AddExecInterceptor(new SecFetchSiteInterceptor(value));
        }

        public static ClientServiceRequest<TResponse> AddSecFetchMode<TResponse>(
            this ClientServiceRequest<TResponse> request,
            string value)
        {
            return request.AddExecInterceptor(new SecFetchModeInterceptor(value));
        }

        public static ClientServiceRequest<TResponse> AddSecFetchUser<TResponse>(
            this ClientServiceRequest<TResponse> request,
            string value)
        {
            return request.AddExecInterceptor(new SecFetchUserInterceptor(value));
        }

        public static ClientServiceRequest<TResponse> AddSecFetchDest<TResponse>(
            this ClientServiceRequest<TResponse> request,
            string value)
        {
            return request.AddExecInterceptor(new SecFetchDestInterceptor(value));
        }
    }
}