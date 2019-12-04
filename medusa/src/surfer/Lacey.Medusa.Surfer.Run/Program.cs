using System;
using System.IO;
using System.Linq;
using Lacey.Medusa.Surfer.Run.Configuration;
using Lacey.Medusa.Surfer.Run.Infrastructure;
using Lacey.Medusa.Surfer.Services.LikesRock.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Run
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
                config.Lr.UserSecretsFile = args[0];
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

            var likesRock = serviceProvider.GetService<ILrSurfService>();

            try
            {
                likesRock.Surf().Wait();
            }
            catch (Exception exc)
            {
                logger.LogError(exc.Message);
            }

            serviceProvider.Dispose();
        }
    }
}
