using Lacey.Medusa.Common.Dal.Dal;
using Lacey.Medusa.Common.Dal.Dal.Concrete;
using Lacey.Medusa.Common.Dal.Infrastructure;
using Lacey.Medusa.Instagram.Dal.Dal;
using Lacey.Medusa.Instagram.Dal.Dal.Concrete;
using Microsoft.EntityFrameworkCore;
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

        public static IServiceCollection AddInstagramDalServicesMultiple(
            this IServiceCollection services,
            string connectionString)
        {
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<InstagramSqlServerDbContext>(options =>
                    options.UseSqlServer(connectionString))

                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IInstagramUnitOfWorkFactory, InstagramUnitOfWorkFactory>()
            
                .AddTransient<IInstagramSessionFactory, InstagramSessionFactory>(
                    provider => new InstagramSessionFactory(connectionString));

            return services;
        }
    }
}