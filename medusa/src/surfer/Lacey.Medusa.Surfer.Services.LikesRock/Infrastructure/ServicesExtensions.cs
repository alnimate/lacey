using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers.Concrete;
using Lacey.Medusa.Surfer.Services.LikesRock.Services;
using Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddLikesRockServices(
            this IServiceCollection services,
            string userSecretsFile,
            string commonSecretsFile)
        {
            services
                .AddTransient<ILikesRockAuthProvider, LikesRockAuthProvider>(
                    provider => new LikesRockAuthProvider(userSecretsFile, commonSecretsFile))

                .AddTransient<ILikesRockAutoSurfService, LikesRockAutoSurfService>(
                    provider => new LikesRockAutoSurfService(
                        provider.GetService<ILogger<LikesRockAutoSurfService>>(),
                        provider.GetService<ILikesRockAuthProvider>()))

                .AddTransient<ILrWebsitesService, LrWebsitesService>(
                    provider => new LrWebsitesService(
                        provider.GetService<ILogger<LrWebsitesService>>(),
                        provider.GetService<ILikesRockAuthProvider>()))

                .AddTransient<ILikesRockSurferService, LikesRockSurferService>(
                    provider => new LikesRockSurferService(
                        provider.GetService<ILogger<LikesRockSurferService>>(),
                        provider.GetService<ILikesRockAuthProvider>(),
                        provider.GetService<ILikesRockAutoSurfService>(),
                        provider.GetService<ILrWebsitesService>()));

            return services;
        }
    }
}