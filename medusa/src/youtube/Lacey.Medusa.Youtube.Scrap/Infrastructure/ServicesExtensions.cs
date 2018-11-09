using AutoMapper;
using Lacey.Medusa.Youtube.Common.Interfaces;
using Lacey.Medusa.Youtube.Scrap.Services.Channels;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Scrap.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddYoutubeScrapServices(
            this IServiceCollection services,
            string tempFolder,
            string outputFolder,
            string converterFilePath)
        {
            services
                .AddTransient<IYoutubeChannelProvider, YoutubeChannelScrapProvider>()
                .AddTransient<IYoutubeDownloadVideoProvider, YoutubeDownloadVideoScrapProvider>(
                    provider => new YoutubeDownloadVideoScrapProvider(
                        provider.GetService<IMapper>(),
                        tempFolder,
                        outputFolder,
                        converterFilePath));

            return services;
        }
    }
}