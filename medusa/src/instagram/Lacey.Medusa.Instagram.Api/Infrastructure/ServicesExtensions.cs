using Lacey.Medusa.Instagram.Api.Services;
using Lacey.Medusa.Instagram.Api.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Instagram.Api.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddInstagramServices(
            this IServiceCollection services,
            string clientSecretsFilePath,
            string instagramStateFilePath)
        {
            services
                .AddTransient<IInstagramAuthProvider, InstagramAuthProvider>(
                    provider => new InstagramAuthProvider(clientSecretsFilePath))
                .AddTransient<IInstagramProvider, InstagramProvider>(
                    provider => new InstagramProvider(
                        provider.GetService<IInstagramAuthProvider>(),
                        provider.GetService<ILogger<InstagramProvider>>(),
                        instagramStateFilePath));

            return services;
        }
    }
}