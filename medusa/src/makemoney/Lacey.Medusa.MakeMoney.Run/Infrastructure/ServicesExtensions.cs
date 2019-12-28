using System.IO;
using Lacey.Medusa.Common.Email.Infrastructure;
using Lacey.Medusa.MakeMoney.Run.Configuration;
using Lacey.Medusa.MakeMoney.Services.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.MakeMoney.Run.Infrastructure
{
    internal static class ServicesExtensions
    {
        public static IServiceCollection AddAppServices(
            this IServiceCollection services,
            AppConfiguration config)
        {
            var currentFolder = Directory.GetCurrentDirectory();

            services
                .AddMakeMoneyServices(
                    config.Mm.UserSecretsFile, 
                    config.Mm.CommonSecretsFile,
                    config.Email.IsSendEmails)
                .AddEmailServices(
                    config.Email.SmtpHost,
                    config.Email.SmtpPort,
                    config.Email.SmtpUsername,
                    Path.Combine(currentFolder, config.Email.SmtpSecretFile));

            return services;
        }
    }
}