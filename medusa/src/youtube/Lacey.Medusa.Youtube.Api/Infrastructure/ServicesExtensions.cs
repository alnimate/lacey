using Lacey.Medusa.Youtube.Api.Services;
using Lacey.Medusa.Youtube.Api.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Api.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddYoutubeServices(
            this IServiceCollection services,
            string clientSecretsFilePath,
            string userName,
            string outputFolder)
        {
            services
                .AddTransient<IYoutubeAuthProvider, YoutubeAuthProvider>(
                    provider => new YoutubeAuthProvider(
                        clientSecretsFilePath,
                        userName))
                .AddTransient<IYoutubeProvider, YoutubeProvider>(
                    provider => new YoutubeProvider(
                        provider.GetService<IYoutubeAuthProvider>(),
                        provider.GetService<ILogger<YoutubeProvider>>(),
                        outputFolder));

            return services;
        }
    }
}