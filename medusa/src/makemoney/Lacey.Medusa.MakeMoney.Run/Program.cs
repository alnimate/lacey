using System;
using System.IO;
using System.Linq;
using Lacey.Medusa.MakeMoney.Run.Configuration;
using Lacey.Medusa.MakeMoney.Run.Infrastructure;
using Lacey.Medusa.MakeMoney.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.MakeMoney.Run
{
    class Program
    {
        private static ILogger<Program> logger;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var config = configuration.GetSection("App").Get<AppConfiguration>();
            if (args != null && args.Any())
            {
                config.Mm.UserSecretsFile = args[0];
            }

            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddLogging(logBuilder =>
                    logBuilder
                        .AddLog4Net()
                        .SetMinimumLevel(LogLevel.Trace))
                .AddAppServices(config)
                .BuildServiceProvider();

            //configure console logging
            logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            var service = serviceProvider.GetService<IMakeMoneyService>();

            try
            {
                service.Run().Wait();
            }
            catch (Exception exc)
            {
                logger.LogError(exc.Message);
            }

            serviceProvider.Dispose();
        }
    }
}
