using Lacey.Medusa.Youtube.Api.Infrastructure;
using Lacey.Medusa.Youtube.Api.Services;
using Lacey.Medusa.Youtube.Dal.Infrastructure;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Services.Transfer.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddYoutubeTransferServices(
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
                .AddTransient<IPlaylistsService, PlaylistsService>()

                .AddTransient<ITransferService, TransferService>(
                    provider => new TransferService(
                        provider.GetService<IYoutubeProvider>(),
                        provider.GetService<ILogger<TransferService>>(),
                        outputFolder,
                        provider.GetService<IChannelsService>(),
                        provider.GetService<IVideosService>(),
                        provider.GetService<IPlaylistsService>()));

            return services;
        }

        public static IServiceCollection AddCleaningServices(
            this IServiceCollection services,
            string clientSecretsFilePath,
            string userName,
            string connectionString)
        {
            services
                .AddYoutubeServices(clientSecretsFilePath, userName)

                .AddYoutubeDalServices(connectionString)
                .AddTransient<IChannelsService, ChannelsService>()
                .AddTransient<IVideosService, VideosService>()
                .AddTransient<IPlaylistsService, PlaylistsService>()

                .AddTransient<IClearService, ClearService>();

            return services;
        }

        public static IServiceCollection AddCopyrightServices(
            this IServiceCollection services,
            string clientSecretsFilePath,
            string userName,
            string outputFolder,
            string connectionString)
        {
            services
                .AddYoutubeServices(clientSecretsFilePath, userName)
                .AddYoutubeDalServices(connectionString)
                .AddTransient<IChannelsService, ChannelsService>()
                .AddTransient<IVideosService, VideosService>()
                .AddTransient<ICopyrightService, CopyrightService>(
                    provider => new CopyrightService(
                        provider.GetService<IYoutubeAuthProvider>(),
                        provider.GetService<IYoutubeProvider>(),
                        provider.GetService<ILogger<CopyrightService>>(),
                        outputFolder,
                        provider.GetService<IChannelsService>(),
                        provider.GetService<IVideosService>()));

            return services;
        }
    }
}