using Lacey.Medusa.Facebook.Api.Services;
using Lacey.Medusa.Facebook.Api.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Facebook.Api.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddFacebookServices(
            this IServiceCollection services,
            string clientSecretsFilePath)
        {
            services
                .AddTransient<IFacebookAuthProvider, FacebookAuthProvider>(
                    provider => new FacebookAuthProvider(clientSecretsFilePath))
                .AddTransient<IFacebookProvider, FacebookProvider>();

            return services;
        }
    }
}