using Lacey.Medusa.Youtube.Transfer.Copyright.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Transfer.Copyright.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddAppServices(
            this IServiceCollection services,
            AppConfiguration config,
            string connectionString)
        {
            return services;
        }
    }
}