using System.IO;
using Lacey.Medusa.Common.Email.Infrastructure;
using Lacey.Medusa.Youtube.Dal.Infrastructure;
using Lacey.Medusa.Youtube.Services.Transfer.Infrastructure;
using Lacey.Medusa.Youtube.Transfer.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Transfer.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddAppServices(
            this IServiceCollection services,
            AppConfiguration config,
            string connectionString)
        {
            var currentFolder = Directory.GetCurrentDirectory();

            services
                .AddYoutubeDalServices(connectionString)
                .AddEmailServices(
                    config.Email.SmtpHost,
                    config.Email.SmtpPort,
                    config.Email.SmtpUsername,
                    Path.Combine(currentFolder, config.Email.SmtpSecretFile))
                .AddYoutubeTransferServices(
                    config.ApiKeyFile,
                    config.ClientSecretsFilePath,
                    config.UserName,
                    Path.Combine(currentFolder, config.TempFolder),
                    Path.Combine(currentFolder, config.OutputFolder),
                    Path.Combine(currentFolder, config.ConverterFile));

            return services;
        }
    }
}