using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Api.Core.Custom.Interceptors;

namespace Lacey.Medusa.Common.Api.Custom.Extensions
{
    public static class ClientServiceExtensions
    {
        public static BaseClientService AddExecuteInterceptor(
            this BaseClientService service,
            IHttpExecuteInterceptor interceptor)
        {
            service.HttpClient.MessageHandler.AddExecuteInterceptor(interceptor);

            return service;
        }

        public static BaseClientService AddUserAgent(
            this BaseClientService service,
            string userAgent)
        {
            return service.AddExecuteInterceptor(new UserAgentInterceptor(userAgent));
        }
    }
}