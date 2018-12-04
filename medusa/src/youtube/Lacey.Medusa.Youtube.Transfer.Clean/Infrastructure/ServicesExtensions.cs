using Lacey.Medusa.Youtube.Api.Infrastructure;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete;
using Lacey.Medusa.Youtube.Transfer.Clean.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Transfer.Clean.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddAppServices(
            this IServiceCollection services,
            AppConfiguration config)
        {
            services
                .AddYoutubeServices(
                    config.ClientSecretsFilePath,
                    config.UserName)

                .AddTransient<IClearService, ClearService>();

            return services;
        }
    }
}