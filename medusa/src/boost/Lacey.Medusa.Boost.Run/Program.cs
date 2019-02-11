using System;
using System.IO;
using System.Text;
using AutoMapper;
using Lacey.Medusa.Boost.Run.Configuration;
using Lacey.Medusa.Boost.Run.Infrastructure;
using Lacey.Medusa.Boost.Services.Services;
using Lacey.Medusa.Common.Email.Services.Email;
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

            Console.WriteLine("Welcome to the Boost tool!");

            var youtubeBooster = serviceProvider.GetService<IYoutubeBooster>();

            var sb = new StringBuilder();
            for (var i = 0; i < config.YoutubeChannels.Length; i++)
            {
                var youtubeChannel = config.YoutubeChannels[i];

                logger.LogTrace($"[{youtubeChannel.ChannelId}]...");

                try
                {
                    youtubeBooster.Boost(youtubeChannel.ChannelId).Wait();
                }
                catch (Exception exc)
                {
                    logger.LogError(exc.Message);
                }

                logger.LogTrace($"[{youtubeChannel.ChannelId}] completed.{Environment.NewLine}");
                sb.AppendLine($"[{youtubeChannel.ChannelId}]");
            }

            if (config.Email.IsSendEmails)
            {
                var emailService = serviceProvider.GetService<IEmailProvider>();
                var currentFolder = Directory.GetCurrentDirectory();
                emailService.Send(
                    config.Email.From,
                    config.Email.To,
                    config.Email.Subject,
                    sb.ToString(),
                    true,
                    new[]
                    {
                        Path.Combine(currentFolder, config.Logs.LogFile)
                    });
            }

            serviceProvider.Dispose();
        }
    }

}
