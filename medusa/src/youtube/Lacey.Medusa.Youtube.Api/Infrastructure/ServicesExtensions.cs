using Lacey.Medusa.Youtube.Api.Services.Auth;
using Lacey.Medusa.Youtube.Api.Services.Auth.Concrete;
using Lacey.Medusa.Youtube.Api.Services.Channels;
using Lacey.Medusa.Youtube.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Api.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddYoutubeApiServices(
            this IServiceCollection services,
            string apiKeyFile)
        {
            services
                .AddTransient<IYoutubeAuthProvider, SimpleYoutubeAuthProvider>(
                    provider => new SimpleYoutubeAuthProvider(apiKeyFile))
                .AddTransient<IYoutubeChannelProvider, YoutubeChannelApiProvider>()
                .AddTransient<IYoutubeDownloadVideoProvider, YoutubeDownloadVideoApiProvider>();

            return services;
        }
    }
}