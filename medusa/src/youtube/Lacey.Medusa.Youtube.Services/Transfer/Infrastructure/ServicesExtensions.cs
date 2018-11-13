using Lacey.Medusa.Youtube.Api.Infrastructure;
using Lacey.Medusa.Youtube.Common.Infrastructure;
using Lacey.Medusa.Youtube.Scrap.Infrastructure;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Services.Transfer.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddYoutubeTransferServices(
            this IServiceCollection services,
            string apiKeyFile,
            string clientSecretsFilePath,
            string userName,
            string tempFolder,
            string outputFolder,
            string converterFilePath)
        {
            services
                .AddYoutubeScrapServices(
                    tempFolder,
                    outputFolder,
                    converterFilePath)

                .AddYoutubeApiServices(
                    apiKeyFile,
                    clientSecretsFilePath,
                    userName)

                // Highest priority providers
                .AddYoutubeServices(
                    tempFolder)

                .AddTransient<ITransferService, TransferService>();

            return services;
        }
    }
}