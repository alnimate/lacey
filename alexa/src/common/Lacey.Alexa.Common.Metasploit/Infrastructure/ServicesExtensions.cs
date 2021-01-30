using Lacey.Alexa.Common.Metasploit.Providers;
using Lacey.Alexa.Common.Metasploit.Providers.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Alexa.Common.Metasploit.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddMetasploitServices(
            this IServiceCollection services,
            string metasploitUrl,
            string metasploitSecretsFile)
        {
            services
                .AddTransient<IMetasploitAuthProvider, MetasploitAuthProvider>(
                    provider => new MetasploitAuthProvider(metasploitSecretsFile))

                .AddTransient<IMetasploitProvider, MetasploitProvider>(
                    provider => new MetasploitProvider(
                        metasploitUrl,
                        provider.GetService<IMetasploitAuthProvider>(),
                        provider.GetService<ILogger<MetasploitProvider>>()));

            return services;
        }
    }
}