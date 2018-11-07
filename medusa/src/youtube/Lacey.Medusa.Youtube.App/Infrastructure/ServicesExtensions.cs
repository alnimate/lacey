using Lacey.Medusa.Common.Dal.Dal;
using Lacey.Medusa.Youtube.Dal.Infrastructure;
using Lacey.Medusa.Youtube.Services.Common.Infrastructure;
using Lacey.Medusa.Youtube.Services.Transfer.Infrastructure;

namespace Lacey.Medusa.Youtube.App.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;

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

            services.AddTransient<ISessionFactory, YoutubeSessionFactory>(
                provider => new YoutubeSessionFactory(connectionString));

            services.AddCommonServices(apiKeyFile)
                .AddTransferServices();

            return services;
        }
}
}