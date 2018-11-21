using Lacey.Medusa.Youtube.Api.Services;
using Lacey.Medusa.Youtube.Api.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Api.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddYoutubeServices(
            this IServiceCollection services,
            string clientSecretsFilePath,
            string userName)
        {
            services
                .AddTransient<IYoutubeAuthProvider, YoutubeAuthProvider>(
                    provider => new YoutubeAuthProvider(
                        clientSecretsFilePath,
                        userName))
                .AddTransient<IYoutubeProvider, YoutubeProvider>();

            return services;
        }
    }
}