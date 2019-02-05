using Lacey.Medusa.Instagram.Api.Services;
using Lacey.Medusa.Instagram.Api.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Instagram.Api.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddInstagramServices(
            this IServiceCollection services,
            string clientSecretsFilePath)
        {
            services
                .AddTransient<IInstagramAuthProvider, InstagramAuthProvider>(
                    provider => new InstagramAuthProvider(clientSecretsFilePath))
                .AddTransient<IInstagramProvider, InstagramProvider>();

            return services;
        }
    }
}