using System.IO;
using Lacey.Medusa.Common.Email.Infrastructure;
using Lacey.Medusa.Instagram.Services.Transfer.Infrastructure;
using Lacey.Medusa.Instagram.Transfer.Run.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Instagram.Transfer.Run.Infrastructure
{
    internal static class ServicesExtensions
    {
        public static IServiceCollection AddAppServices(
            this IServiceCollection services,
            AppConfiguration config,
            string connectionString)
        {
            var currentFolder = Directory.GetCurrentDirectory();

            services
                .AddEmailServices(
                    config.Email.SmtpHost,
                    config.Email.SmtpPort,
                    config.Email.SmtpUsername,
                    Path.Combine(currentFolder, config.Email.SmtpSecretFile))
                .AddInstagramTransferServices(
                    config.ClientSecretsFilePath,
                    config.InstagramStateFile,
                    Path.Combine(currentFolder, config.TempFolder),
                    connectionString,
                    config.Threshold);

            return services;
        }
    }
}