using Lacey.Alexa.Common.Metasploit.Infrastructure;
using Lacey.Alexa.Common.Metasploit.Providers;
using Lacey.Alexa.Explorer.Services.Services;
using Lacey.Alexa.Explorer.Services.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Alexa.Explorer.Services.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddExplorerServices(
            this IServiceCollection services,
            string metasploitUrl,
            string metasploitSecretsFile)
        {
            services
                .AddMetasploitServices(
                    metasploitUrl,
                    metasploitSecretsFile)

                .AddTransient<IExplorerService, ExplorerService>(
                    provider => new ExplorerService(
                        provider.GetService<IMetasploitProvider>(),
                        provider.GetService<ILogger<ExplorerService>>()));
            return services;
        }
    }
}