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
            string secretsFilePath)
        {
            services
                .AddTransient<ILikesRockAuthProvider, LikesRockAuthProvider>(
                    provider => new LikesRockAuthProvider(secretsFilePath))
                .AddTransient<ILikesRockAuthService, LikesRockAuthService>(
                    provider => new LikesRockAuthService(
                        provider.GetService<ILikesRockAuthProvider>(),
                        provider.GetService<ILogger<LikesRockAuthService>>()))
                .AddTransient<ILikesRockAutoSurfService, LikesRockAutoSurfService>(
                    provider => new LikesRockAutoSurfService(
                        provider.GetService<ILogger<LikesRockAutoSurfService>>()))
                .AddTransient<ILikesRockSurferService, LikesRockSurferService>(
                    provider => new LikesRockSurferService(
                        provider.GetService<ILogger<LikesRockSurferService>>(),
                        provider.GetService<ILikesRockAuthService>(),
                        provider.GetService<ILikesRockAutoSurfService>()));

            return services;
        }
    }
}