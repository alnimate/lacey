using Lacey.Medusa.Youtube.Dal.Infrastructure;
using Lacey.Medusa.Youtube.Services.Transfer.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Transfer.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddAppServices(
            this IServiceCollection services,
            string connectionString,
            string apiKeyFile,
            string tempFolder,
            string outputFolder,
            string converterFilePath)
        {

            services
                .AddYoutubeDalServices(connectionString)
                .AddYoutubeTransferServices(
                    apiKeyFile,
                    tempFolder,
                    outputFolder,
                    converterFilePath);

            return services;
        }
    }
}