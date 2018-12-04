using System;
using System.IO;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Lacey.Medusa.Youtube.Transfer.Clean.Configuration;
using Lacey.Medusa.Youtube.Transfer.Clean.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Transfer.Clean
{
    class Program
    {
        private static ILogger<Program> logger;

        static void Main()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var config = configuration.GetSection("App").Get<AppConfiguration>();

            //setup our DI
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

            logger.LogTrace("Welcome to the YouTube cleaning tool!");
            Console.WriteLine("Are you sure to start cleaning process? (y/n)");
            var answer = Console.ReadLine();
            if (answer == "y")
            {
                var clearService = serviceProvider.GetService<IClearService>();
                for (var i = 0; i < config.Channels.Length; i++)
                {
                    var channelId = config.Channels[i];
                    try
                    {
                        logger.LogTrace($"Cleaning [{channelId}]...");
                        clearService.ClearChannel(channelId).Wait();
                        logger.LogTrace($"Cleaning [{channelId}] completed.");
                    }
                    catch (Exception exc)
                    {
                        logger.LogError(exc.Message);
                    }
                }
            }

            serviceProvider.Dispose();
        }
    }
}
