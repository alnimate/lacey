using System;
using System.IO;
using System.Text;
using AutoMapper;
using Lacey.Medusa.Common.Email.Services.Email;
using Lacey.Medusa.Instagram.Services.Transfer.Services;
using Lacey.Medusa.Instagram.Transfer.Run.Configuration;
using Lacey.Medusa.Instagram.Transfer.Run.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Instagram.Transfer.Run
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

            logger.LogTrace("Welcome to the Instagram transferring tool!");
            Console.WriteLine("0 - Save Media; 1 - Upload Media; 2 - Transfer Media;");
            var answer = Console.ReadLine();

            var transferService = serviceProvider.GetService<ITransferService>();

            var sb = new StringBuilder();
            for (var i = 0; i < config.SourceChannels.Length; i++)
            {
                var sourceChannelId = config.SourceChannels[i];
                var destChannelId = config.DestChannels[i];
                try
                {
                    if (answer == "0")
                    {
                        logger.LogTrace($"Save Media [{sourceChannelId}] => [{destChannelId}]...");
                        transferService.SaveMedia(sourceChannelId, destChannelId).Wait();
                        logger.LogTrace($"Save Media [{sourceChannelId}] => [{destChannelId}] Completed.{Environment.NewLine}");
                        sb.AppendLine($"[https://www.instagram.com/{sourceChannelId}] => [https://www.instagram.com/{destChannelId}]");
                    }
                    else if (answer == "1")
                    {
                        logger.LogTrace($"Upload Media [{sourceChannelId}] => [{destChannelId}]...");
                        transferService.UploadMedia(sourceChannelId, destChannelId).Wait();
                        logger.LogTrace($"Upload Media [{sourceChannelId}] => [{destChannelId}] Completed.{Environment.NewLine}");
                        sb.AppendLine($"[https://www.instagram.com/{sourceChannelId}] => [https://www.instagram.com/{destChannelId}]");
                    }
                    else if (answer == "2")
                    {
                        logger.LogTrace($"Transfer Media [{sourceChannelId}] => [{destChannelId}]...");
                        transferService.TransferMedia(sourceChannelId, destChannelId).Wait();
                        logger.LogTrace($"Transfer Media [{sourceChannelId}] => [{destChannelId}] Completed.{Environment.NewLine}");
                        sb.AppendLine($"[https://www.instagram.com/{sourceChannelId}] => [https://www.instagram.com/{destChannelId}]");
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
