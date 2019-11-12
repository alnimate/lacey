using System.IO;
using Lacey.Medusa.Common.Email.Infrastructure;
using Lacey.Medusa.Surfer.Run.Configuration;
using Lacey.Medusa.Surfer.Services.LikesRock.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Surfer.Run.Infrastructure
{
    internal static class ServicesExtensions
    {
        public static IServiceCollection AddAppServices(
            this IServiceCollection services,
            AppConfiguration config)
        {
            var currentFolder = Directory.GetCurrentDirectory();

            services
                .AddLikesRockServices(
                    config.Lr.UserSecretsFile, 
                    config.Lr.CommonSecretsFile)
                .AddEmailServices(
                    config.Email.SmtpHost,
                    config.Email.SmtpPort,
                    config.Email.SmtpUsername,
                    Path.Combine(currentFolder, config.Email.SmtpSecretFile));

            return services;
        }
    }
}