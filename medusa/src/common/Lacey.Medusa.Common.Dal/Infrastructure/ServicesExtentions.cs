using Lacey.Medusa.Common.Dal.Dal;
using Lacey.Medusa.Common.Dal.Dal.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Common.Dal.Infrastructure
{
    public static class ServicesExtentions
    {
        /// <summary>
        /// Entity Framework data access layer registration
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IServiceCollection AddEntityFramework<TDbContext>(
            this IServiceCollection services,
            string connectionString) where TDbContext : DbContext
        {
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<TDbContext>(options => 
                    options.UseSqlServer(connectionString, opt => opt.UseRowNumberForPaging()));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();

            return services;
        }
    }
}