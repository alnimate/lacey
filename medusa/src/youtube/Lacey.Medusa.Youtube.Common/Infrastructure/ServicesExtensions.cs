using Lacey.Medusa.Youtube.Common.Services;
using Lacey.Medusa.Youtube.Common.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Common.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddYoutubeServices(
            this IServiceCollection services,
            string outputFolder)
        {
            services
                .AddTransient<IYoutubeDownloadVideoProvider, YoutubeDownloadVideoProvider>(
                    provider => new YoutubeDownloadVideoProvider(
                        provider.GetService<ILogger<YoutubeDownloadVideoProvider>>(),
                        outputFolder));

            return services;
        }
    }
}