using Lacey.Medusa.Youtube.Dal.Infrastructure;
using Lacey.Medusa.Youtube.Services.Common.Infrastructure;
using Lacey.Medusa.Youtube.Services.Transfer.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Transfer.Infrastructure
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Application services registration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <param name="apiKeyFile"></param>
        /// <returns></returns>
        public static IServiceCollection AddAppServices(
            this IServiceCollection services,
            string connectionString,
            string apiKeyFile)
        {

            services
                .AddYoutubeDalServices(connectionString)
                .AddYoutubeCommonServices(apiKeyFile)
                .AddYoutubeTransferServices();

            return services;
        }
    }
}