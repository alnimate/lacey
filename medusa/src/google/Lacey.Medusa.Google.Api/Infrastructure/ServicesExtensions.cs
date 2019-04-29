using Lacey.Medusa.Google.Api.Services;
using Lacey.Medusa.Google.Api.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Google.Api.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddGoogleServices(
            this IServiceCollection services,
            string clientSecretsFilePath)
        {
            services
                .AddTransient<IGoogleAuthProvider, GoogleAuthProvider>(
                    provider => new GoogleAuthProvider(clientSecretsFilePath))
                .AddTransient<IGoogleProvider, GoogleProvider>();

            return services;
        }
    }
}