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
                .AddTransient<ILrAuthProvider, LrAuthProvider>(
                    provider => new LrAuthProvider(userSecretsFile, commonSecretsFile))

                .AddTransient<ILrLoginService, LrLoginService>(
                    provider => new LrLoginService(
                        provider.GetService<ILogger<LrLoginService>>(),
                        provider.GetService<ILrAuthProvider>()))

                .AddTransient<ILrAutoSurfService, LrAutoSurfService>(
                    provider => new LrAutoSurfService(
                        provider.GetService<ILogger<LrAutoSurfService>>(),
                        provider.GetService<ILrAuthProvider>()))

                .AddTransient<ILrTasksService, LrTasksService>(
                    provider => new LrTasksService(
                        provider.GetService<ILogger<LrTasksService>>(),
                        provider.GetService<ILrAuthProvider>()))

                .AddTransient<ILrSurfService, LrSurfService>(
                    provider => new LrSurfService(
                        provider.GetService<ILogger<LrSurfService>>(),
                        provider.GetService<ILrAuthProvider>(),
                        provider.GetService<ILrAutoSurfService>(),
                        provider.GetService<ILrTasksService>(),
                        provider.GetService<ILrLoginService>()));

            return services;
        }
    }
}