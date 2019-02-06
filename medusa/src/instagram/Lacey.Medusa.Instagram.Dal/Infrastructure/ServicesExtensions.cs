using Lacey.Medusa.Common.Dal.Dal;
using Lacey.Medusa.Common.Dal.Infrastructure;
using Lacey.Medusa.Instagram.Dal.Dal;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Instagram.Dal.Infrastructure
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Application services registration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IServiceCollection AddInstagramDalServices(
            this IServiceCollection services,
            string connectionString)
        {
            services
                .AddCommonDalServices<InstagramSqlServerDbContext>(connectionString)
                .AddTransient<ISessionFactory, InstagramSessionFactory>(
                    provider => new InstagramSessionFactory(connectionString));

            return services;
        }
    }
}