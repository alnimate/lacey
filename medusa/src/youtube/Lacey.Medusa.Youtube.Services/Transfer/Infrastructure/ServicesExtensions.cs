using Lacey.Medusa.Youtube.Api.Infrastructure;
using Lacey.Medusa.Youtube.Scrap.Infrastructure;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Services.Transfer.Infrastructure
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Application services registration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="apiKeyFile"></param>
        /// <returns></returns>
        public static IServiceCollection AddYoutubeTransferServices(
            this IServiceCollection services,
            string apiKeyFile)
        {
            services
//                .AddYoutubeApiServices(apiKeyFile)
                .AddYoutubeScrapServices()

                .AddTransient<ITransferService, TransferService>();

            return services;
        }
    }
}