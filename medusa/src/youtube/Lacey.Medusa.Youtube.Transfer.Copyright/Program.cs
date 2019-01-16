using System.IO;
using System.Linq;
using AutoMapper;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Lacey.Medusa.Youtube.Transfer.Copyright.Configuration;
using Lacey.Medusa.Youtube.Transfer.Copyright.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Transfer.Copyright
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
            var connectionString = configuration.GetConnectionString("Default");

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddAutoMapper()
                .AddLogging(logBuilder =>
                    logBuilder
                        .AddLog4Net()
                        .SetMinimumLevel(LogLevel.Trace))
                .AddAppServices(config, connectionString)
                .BuildServiceProvider();

            //configure console logging
            logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogTrace("Welcome to the YouTube copyright tool!");

            var copyrightService = serviceProvider.GetService<ICopyrightService>();

            foreach (var channel in config.Channels)
            {
                var copyrightNotices = copyrightService.GetCopyrightNotices(channel)
                                                .GetAwaiter()
                                                .GetResult();
            }

            serviceProvider.Dispose();
        }
    }
}
