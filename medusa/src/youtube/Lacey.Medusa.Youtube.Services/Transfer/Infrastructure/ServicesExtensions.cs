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

                .AddTransient<ITransferService, TransferService>(
                    provider => new TransferService(
                        provider.GetService<IYoutubeProvider>(),
                        provider.GetService<ILogger<TransferService>>(),
                        outputFolder))
                .AddTransient<IClearService, ClearService>();

            return services;
        }
    }
}