using System.IO;
using Lacey.Medusa.Boost.Run.Configuration;
using Lacey.Medusa.Boost.Services.Infrastructure;
using Lacey.Medusa.Common.Email.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Boost.Run.Infrastructure
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
                .AddBoostServices(
                    config.ClientSecretsFilePath,
                    config.UserName,
                    Path.Combine(currentFolder, config.TempFolder),
                    connectionString);

            return services;
        }
    }
}