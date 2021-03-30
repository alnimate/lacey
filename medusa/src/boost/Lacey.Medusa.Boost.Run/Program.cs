using System;
using System.IO;
using Lacey.Medusa.Boost.Run.Configuration;
using Lacey.Medusa.Boost.Run.Infrastructure;
using Lacey.Medusa.Boost.Services.Boosters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Boost.Run
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
            var youtubeConnectionString = configuration.GetConnectionString("YoutubeConnectionString");
            var instagramConnectionString = configuration.GetConnectionString("InstagramConnectionString");

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddLogging(logBuilder =>
                    logBuilder
                        .AddLog4Net()
                        .SetMinimumLevel(LogLevel.Trace))
                .AddAppServices(config, 
                    youtubeConnectionString,
                    instagramConnectionString)
                .BuildServiceProvider();

            //configure console logging
            logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            Console.WriteLine("Welcome to the Boost tool!");

            var youtubeBooster = serviceProvider.GetService<IYoutubeBooster>();
            for (var i = 0; i < config.YoutubeChannels.Length; i++)
            {
                var youtubeChannel = config.YoutubeChannels[i];
                try
                {
                    youtubeBooster.Boost(
                        youtubeChannel.ChannelId, 
                        youtubeChannel.Instagram,
                        config.BoostInterval).Wait();
                }
                catch (Exception exc)
                {
                    logger.LogError(exc.Message);
                }

            }
            youtubeBooster.Dispose();
            serviceProvider.Dispose();
        }
    }

}
