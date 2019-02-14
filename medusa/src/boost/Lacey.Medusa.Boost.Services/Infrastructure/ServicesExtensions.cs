using Lacey.Medusa.Boost.Services.Services;
using Lacey.Medusa.Boost.Services.Services.Concrete;
using Lacey.Medusa.Instagram.Api.Infrastructure;
using Lacey.Medusa.Instagram.Dal.Infrastructure;
using Lacey.Medusa.Instagram.Services.Transfer.Services;
using Lacey.Medusa.Instagram.Services.Transfer.Services.Concrete;
using Lacey.Medusa.Youtube.Api.Infrastructure;
using Lacey.Medusa.Youtube.Dal.Infrastructure;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ChannelsService = Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete.ChannelsService;
using IChannelsService = Lacey.Medusa.Youtube.Services.Transfer.Services.IChannelsService;

namespace Lacey.Medusa.Boost.Services.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddBoostServices(
            this IServiceCollection services,
            string youtubeClientSecretsFile,
            string instagramClientSecretsFile,
            string userName,
            string outputFolder,
            string youtubeConnectionString,
            string instagramConnectionString)
        {
            services
                .AddYoutubeServices(youtubeClientSecretsFile, userName)
                .AddYoutubeDalServices(youtubeConnectionString)
                .AddTransient<IChannelsService, ChannelsService>()
                .AddTransient<IVideosService, VideosService>()
                .AddTransient<IYoutubeBoostProvider, YoutubeBoostProvider>()

                .AddInstagramServices(instagramClientSecretsFile)
                .AddInstagramDalServices(instagramConnectionString)
                .AddTransient<Instagram.Services.Transfer.Services.IChannelsService, Instagram.Services.Transfer.Services.Concrete.ChannelsService>()
                .AddTransient<IMediaService, MediaService>()
                .AddTransient<IInstagramBoostProvider, InstagramBoostProvider>()

                .AddTransient<IYoutubeBooster, YoutubeBooster>(
                    provider => new YoutubeBooster(
                        provider.GetService<IYoutubeBoostProvider>(),
                        provider.GetService<IInstagramBoostProvider>(),
                        provider.GetService<ILogger<YoutubeBooster>>(),
                        outputFolder,
                        provider.GetService<IChannelsService>(),
                        provider.GetService<IVideosService>(),
                        provider.GetService<Instagram.Services.Transfer.Services.IChannelsService>(),
                        provider.GetService<IMediaService>()));

            return services;
        }
    }
}