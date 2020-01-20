using Lacey.Medusa.Vendor.AdColony.Services;
using Lacey.Medusa.Vendor.AdColony.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Vendor.AdColony.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddAdColonyServices(
            this IServiceCollection services)
        {
            services
                .AddTransient<IAds30Service, Ads30Service>(
                    provider => new Ads30Service(
                        provider.GetService<ILogger<Ads30Service>>()));

            return services;
        }
    }
}