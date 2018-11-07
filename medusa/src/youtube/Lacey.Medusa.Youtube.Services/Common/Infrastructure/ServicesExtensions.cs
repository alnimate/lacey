using Lacey.Medusa.Youtube.Api.Services.Auth;
using Lacey.Medusa.Youtube.Api.Services.Auth.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Services.Common.Infrastructure
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Application services registration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="apiKeyFile"></param>
        /// <returns></returns>
        public static IServiceCollection AddYoutubeCommonServices(
            this IServiceCollection services,
            string apiKeyFile)
        {
            services.AddTransient<IYoutubeAuthProvider, SimpleYoutubeAuthProvider>(
                provider => new SimpleYoutubeAuthProvider(apiKeyFile));

            return services;
        }
    }
}