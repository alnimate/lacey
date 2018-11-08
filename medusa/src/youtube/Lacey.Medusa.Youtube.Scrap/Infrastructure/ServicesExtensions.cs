using Lacey.Medusa.Youtube.Common.Interfaces;
using Lacey.Medusa.Youtube.Scrap.Services.Channels;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Scrap.Infrastructure
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Application services registration
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddYoutubeScrapServices(
            this IServiceCollection services)
        {
            services
                .AddTransient<IYoutubeChannelProvider, YoutubeChannelScrapProvider>();

            return services;
        }
    }
}