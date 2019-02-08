using System;
using System.IO;
using System.Text;
using AutoMapper;
using Lacey.Medusa.Common.Email.Services.Email;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Lacey.Medusa.Youtube.Transfer.Run.Configuration;
using Lacey.Medusa.Youtube.Transfer.Run.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Transfer.Run
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

            logger.LogTrace("Welcome to the YouTube transferring tool!");
            Console.WriteLine("1 - Channel Info; 2 - Videos; 3 - Thumbnails; 4 - Playlists; 5 - Sections; 6 - Subscriptions; 7 - Instagram; 0 - Full Transfer;");
            var answer = Console.ReadLine();

            var transferService = serviceProvider.GetService<ITransferService>();

            var sb = new StringBuilder();
            for (var i = 0; i < config.SourceChannels.Length; i++)
            {
                var sourceChannelId = config.SourceChannels[i].ChannelId;
                var destChannelId = config.DestChannels[i].ChannelId;

                var sourceInstagram = config.SourceChannels[i].Instagram;
                var destInstagram = config.DestChannels[i].Instagram;

                try
                {
                    if (answer == "0")
                    {
                        logger.LogTrace($"[{sourceChannelId}] => [{destChannelId}]...");
                        transferService.TransferChannel(sourceChannelId, destChannelId).Wait();
                        logger.LogTrace($"[{sourceChannelId}] => [{destChannelId}] completed.{Environment.NewLine}");
                        sb.AppendLine($"[https://www.youtube.com/channel/{sourceChannelId}] => [https://www.youtube.com/channel/{destChannelId}]");
                    }
                    else if (answer == "1")
                    {
                        logger.LogTrace($"Channel Info [{sourceChannelId}] => [{destChannelId}]...");
                        transferService.TransferMetadata(sourceChannelId, destChannelId).Wait();
                        logger.LogTrace($"Channel Info [{sourceChannelId}] => [{destChannelId}] Completed.{Environment.NewLine}");
                        sb.AppendLine($"[https://www.youtube.com/channel/{sourceChannelId}] => [https://www.youtube.com/channel/{destChannelId}]");
                    }
                    else if (answer == "2")
                    {
                        logger.LogTrace($"Videos [{sourceChannelId}] => [{destChannelId}]...");
                        transferService.TransferVideos(sourceChannelId, destChannelId).Wait();
                        logger.LogTrace($"Videos [{sourceChannelId}] => [{destChannelId}] Completed.{Environment.NewLine}");
                        sb.AppendLine($"[https://www.youtube.com/channel/{sourceChannelId}] => [https://www.youtube.com/channel/{destChannelId}]");
                    }
                    else if (answer == "3")
                    {
                        logger.LogTrace($"Thumbnails [{sourceChannelId}] => [{destChannelId}]...");
                        transferService.SetThumbnails(sourceChannelId, destChannelId).Wait();
                        logger.LogTrace($"Thumbnails [{sourceChannelId}] => [{destChannelId}] Completed.{Environment.NewLine}");
                        sb.AppendLine($"[https://www.youtube.com/channel/{sourceChannelId}] => [https://www.youtube.com/channel/{destChannelId}]");
                    }
                    else if (answer == "4")
                    {
                        logger.LogTrace($"Playlists [{sourceChannelId}] => [{destChannelId}]...");
                        transferService.TransferPlaylists(sourceChannelId, destChannelId).Wait();
                        logger.LogTrace($"Playlists [{sourceChannelId}] => [{destChannelId}] Completed.{Environment.NewLine}");
                        sb.AppendLine($"[https://www.youtube.com/channel/{sourceChannelId}] => [https://www.youtube.com/channel/{destChannelId}]");
                    }
                    else if (answer == "5")
                    {
                        logger.LogTrace($"Sections [{sourceChannelId}] => [{destChannelId}]...");
                        transferService.TransferSections(sourceChannelId, destChannelId).Wait();
                        logger.LogTrace($"Sections [{sourceChannelId}] => [{destChannelId}] Completed.{Environment.NewLine}");
                        sb.AppendLine($"[https://www.youtube.com/channel/{sourceChannelId}] => [https://www.youtube.com/channel/{destChannelId}]");
                    }
                    else if (answer == "6")
                    {
                        logger.LogTrace($"Subscriptions [{sourceChannelId}] => [{destChannelId}]...");
                        transferService.TransferSubscriptions(sourceChannelId, destChannelId).Wait();
                        logger.LogTrace($"Subscriptions [{sourceChannelId}] => [{destChannelId}] Completed.{Environment.NewLine}");
                        sb.AppendLine($"[https://www.youtube.com/channel/{sourceChannelId}] => [https://www.youtube.com/channel/{destChannelId}]");
                    }
                    else if (answer == "7")
                    {
                        logger.LogTrace($"Instagram [{sourceChannelId}] => [{destChannelId}]...");
                        transferService.UpdateInstagram(destChannelId, sourceInstagram, destInstagram).Wait();
                        logger.LogTrace($"Instagram [{sourceChannelId}] => [{destChannelId}] Completed.{Environment.NewLine}");
                        sb.AppendLine($"[https://www.youtube.com/channel/{sourceChannelId}] => [https://www.youtube.com/channel/{destChannelId}]");
                    }
                }
                catch (Exception exc)
                {
                    logger.LogError(exc.Message);
                }
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
