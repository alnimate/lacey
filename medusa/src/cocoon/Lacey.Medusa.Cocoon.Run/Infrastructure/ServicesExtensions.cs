using System.IO;
using Lacey.Medusa.Cocoon.Run.Configuration;
using Lacey.Medusa.Common.Email.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Cocoon.Run.Infrastructure
{
    internal static class ServicesExtensions
    {
        public static IServiceCollection AddAppServices(
            this IServiceCollection services,
            AppConfiguration config)
        {
            var currentFolder = Directory.GetCurrentDirectory();

            services
                .AddEmailServices(
                    config.Email.SmtpHost,
                    config.Email.SmtpPort,
                    config.Email.SmtpUsername,
                    Path.Combine(currentFolder, config.Email.SmtpSecretFile));

            return services;
        }
    }
}