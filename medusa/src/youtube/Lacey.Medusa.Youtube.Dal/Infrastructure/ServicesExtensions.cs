using Lacey.Medusa.Common.Dal.Dal;
using Lacey.Medusa.Common.Dal.Dal.Concrete;
using Lacey.Medusa.Youtube.Dal.Dal;
using Lacey.Medusa.Youtube.Dal.Dal.Concrete;
using Microsoft.EntityFrameworkCore;
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
                .AddEntityFrameworkSqlServer()
                .AddDbContext<YoutubeSqlServerDbContext>(options =>
                    options.UseSqlServer(connectionString))

                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IYoutubeUnitOfWorkFactory, YoutubeUnitOfWorkFactory>()

                .AddTransient<IYoutubeSessionFactory, YoutubeSessionFactory>(
                    provider => new YoutubeSessionFactory(connectionString));

            return services;
        }
    }
}