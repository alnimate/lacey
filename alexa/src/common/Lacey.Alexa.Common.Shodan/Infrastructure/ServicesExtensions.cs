using System.IO;
using Lacey.Alexa.Common.Shodan.Providers;
using Lacey.Alexa.Common.Shodan.Providers.Concrete;
using Lacey.Alexa.Common.Shodan.Services;
using Lacey.Alexa.Common.Shodan.Services.Concrete;
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

                .AddTransient<IShodanLoginService, ShodanLoginService>(
                    provider => new ShodanLoginService(
                        Path.Combine(Path.GetDirectoryName(shodanSecretsFile) ?? string.Empty, "session.sec"),
                        provider.GetService<IShodanAuthProvider>(),
                        provider.GetService<ILogger<ShodanLoginService>>()))


                .AddTransient<IShodanService, ShodanService>(
                    provider => new ShodanService(
                        provider.GetService<IShodanAuthProvider>(),
                        provider.GetService<ILogger<ShodanService>>()));

            return services;
        }
    }
}