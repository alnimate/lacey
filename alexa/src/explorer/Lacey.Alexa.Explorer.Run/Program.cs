using System;
using System.IO;
using Lacey.Alexa.Explorer.Run.Configuration;
using Lacey.Alexa.Explorer.Run.Infrastructure;
using Lacey.Alexa.Explorer.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Alexa.Explorer.Run
{
    class Program
    {
        private static ILogger<Program> _logger;

        static void Main()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var config = configuration.GetSection("App").Get<AppConfiguration>();

            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddLogging(logBuilder =>
                    logBuilder
                        .AddLog4Net()
                        .SetMinimumLevel(LogLevel.Trace))
                .AddAppServices(config)
                .BuildServiceProvider();

            //configure console logging
            _logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            var service = serviceProvider.GetService<IExplorerService>();

            try
            {
                service?.Run().Wait();
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
            }

            serviceProvider.Dispose();
        }
    }
}
