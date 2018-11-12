using Lacey.Medusa.Common.Email.Infrastructure;
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
            string clientSecretsFilePath,
            string userName,
            string tempFolder,
            string outputFolder,
            string converterFilePath,
            string smtpHost,
            int smtpPort,
            string smtpUserName,
            string smtpSecretFilePath)
        {

            services
                .AddYoutubeDalServices(connectionString)
                .AddEmailServices(
                    smtpHost,
                    smtpPort,
                    smtpUserName, 
                    smtpSecretFilePath)
                .AddYoutubeTransferServices(
                    apiKeyFile,
                    clientSecretsFilePath,
                    userName,
                    tempFolder,
                    outputFolder,
                    converterFilePath);

            return services;
        }
    }
}