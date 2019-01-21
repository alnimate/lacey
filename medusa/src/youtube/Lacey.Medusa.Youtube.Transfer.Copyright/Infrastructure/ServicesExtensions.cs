using System.IO;
using Lacey.Medusa.Youtube.Services.Transfer.Infrastructure;
using Lacey.Medusa.Youtube.Transfer.Copyright.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Transfer.Copyright.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddAppServices(
            this IServiceCollection services,
            AppConfiguration config,
            string connectionString)
        {
            var currentFolder = Directory.GetCurrentDirectory();

            services.AddCopyrightServices(
                config.ClientSecretsFilePath,
                config.UserName,
                Path.Combine(currentFolder, config.TempFolder),
                connectionString);

            return services;
        }
    }
}