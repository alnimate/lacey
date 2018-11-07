using Lacey.Medusa.Common.Dal.Dal;
using Lacey.Medusa.Common.Dal.Infrastructure;
using Lacey.Medusa.Youtube.Dal.Dal;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Dal.Infrastructure
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Application services registration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IServiceCollection AddYoutubeDalServices(
            this IServiceCollection services,
            string connectionString)
        {
            services
                .AddCommonDalServices<YoutubeSqlServerDbContext>(connectionString)
                .AddTransient<ISessionFactory, YoutubeSessionFactory>(
                    provider => new YoutubeSessionFactory(connectionString));

            return services;
        }
    }
}