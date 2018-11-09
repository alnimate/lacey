using Lacey.Medusa.Youtube.Services.Store.Services;
using Lacey.Medusa.Youtube.Services.Store.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Services.Store.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddYoutubeStoreServices(
            this IServiceCollection services,
            string apiKeyFile)
        {
            services
                .AddTransient<IStoreService, StoreService>();

            return services;
        }
    }
}