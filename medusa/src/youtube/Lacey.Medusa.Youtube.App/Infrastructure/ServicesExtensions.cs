using Lacey.Medusa.Common.Dal.Dal;
using Lacey.Medusa.Youtube.Dal.Infrastructure;
using Lacey.Medusa.Youtube.Services.Api.Services.Auth;
using Lacey.Medusa.Youtube.Services.Api.Services.Auth.Concrete;
using Lacey.Medusa.Youtube.Services.Api.Services.Videos;
using Lacey.Medusa.Youtube.Services.Api.Services.Videos.Concrete;
using Lacey.Medusa.Youtube.Services.Database.Services.Videos;
using Lacey.Medusa.Youtube.Services.Database.Services.Videos.Concrete;

namespace Lacey.Medusa.Youtube.App.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ServicesExtensions
    {
        /// <summary>
        /// Application services registration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <param name="apiKeyFile"></param>
        /// <returns></returns>
        public static IServiceCollection AddAppServices(
            this IServiceCollection services,
            string connectionString,
            string apiKeyFile)
        {

            services.AddTransient<ISessionFactory, YoutubeSessionFactory>(
                provider => new YoutubeSessionFactory(connectionString));

            services.AddTransient<IYoutubeAuthProvider, SimpleYoutubeAuthProvider>(
                provider => new SimpleYoutubeAuthProvider(apiKeyFile));

            services.AddTransient<IYoutubeVideosService, YoutubeVideosService>();
            services.AddTransient<IVideosService, VideosService>();

            return services;
        }
    }
}