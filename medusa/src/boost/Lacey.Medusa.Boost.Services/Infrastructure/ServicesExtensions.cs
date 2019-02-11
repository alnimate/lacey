using Lacey.Medusa.Boost.Services.Services;
using Lacey.Medusa.Boost.Services.Services.Concrete;
using Lacey.Medusa.Youtube.Api.Infrastructure;
using Lacey.Medusa.Youtube.Dal.Infrastructure;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Boost.Services.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddBoostServices(
            this IServiceCollection services,
            string clientSecretsFilePath,
            string userName,
            string outputFolder,
            string connectionString)
        {
            services
                .AddYoutubeServices(
                    clientSecretsFilePath,
                    userName)

                .AddYoutubeDalServices(connectionString)
                .AddTransient<IChannelsService, ChannelsService>()
                .AddTransient<IVideosService, VideosService>()

                .AddTransient<IYoutubeBoostProvider, YoutubeBoostProvider>()

                .AddTransient<IYoutubeBooster, YoutubeBooster>(
                    provider => new YoutubeBooster(
                        provider.GetService<IYoutubeBoostProvider>(),
                        provider.GetService<ILogger<YoutubeBooster>>(),
                        outputFolder,
                        provider.GetService<IChannelsService>(),
                        provider.GetService<IVideosService>()));

            return services;
        }
    }
}