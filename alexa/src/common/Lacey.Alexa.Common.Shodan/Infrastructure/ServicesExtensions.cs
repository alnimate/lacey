using Lacey.Alexa.Common.Shodan.Providers;
using Lacey.Alexa.Common.Shodan.Providers.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Alexa.Common.Shodan.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddShodanServices(
            this IServiceCollection services,
            string shodanSecretsFile)
        {
            services
                .AddTransient<IShodanAuthProvider, ShodanAuthProvider>(
                    _ => new ShodanAuthProvider(shodanSecretsFile))

                .AddTransient<IShodanProvider, ShodanProvider>(
                    provider => new ShodanProvider(
                        provider.GetService<IShodanAuthProvider>(),
                        provider.GetService<ILogger<ShodanProvider>>()));

            return services;
        }
    }
}