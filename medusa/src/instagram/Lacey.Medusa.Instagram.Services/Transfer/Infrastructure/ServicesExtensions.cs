using Lacey.Medusa.Instagram.Api.Infrastructure;
using Lacey.Medusa.Instagram.Api.Services;
using Lacey.Medusa.Instagram.Dal.Infrastructure;
using Lacey.Medusa.Instagram.Services.Transfer.Services;
using Lacey.Medusa.Instagram.Services.Transfer.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Instagram.Services.Transfer.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddInstagramTransferServices(
            this IServiceCollection services,
            string clientSecretsFilePath,
            string instagramStateFilePath,
            string outputFolder,
            string connectionString,
            int threshold)
        {
            services
                .AddInstagramServices(clientSecretsFilePath, instagramStateFilePath)
                .AddInstagramDalServices(connectionString)
                .AddTransient<IChannelsService, ChannelsService>()
                .AddTransient<IMediaService, MediaService>()

                .AddTransient<ITransferService, TransferService>(
                    provider => new TransferService(
                        provider.GetService<IInstagramProvider>(),
                        provider.GetService<ILogger<TransferService>>(),
                        outputFolder,
                        provider.GetService<IChannelsService>(),
                        provider.GetService<IMediaService>(),
                        threshold));

            return services;
        }
    }
}