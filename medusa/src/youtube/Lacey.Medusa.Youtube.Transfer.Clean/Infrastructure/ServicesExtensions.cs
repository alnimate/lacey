using Lacey.Medusa.Youtube.Services.Transfer.Infrastructure;
using Lacey.Medusa.Youtube.Transfer.Clean.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Transfer.Clean.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddAppServices(
            this IServiceCollection services,
            AppConfiguration config)
        {
            services
                .AddCleaningServices(
                    config.ClientSecretsFilePath,
                    config.UserName);

            return services;
        }
    }
}