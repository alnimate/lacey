using System;
using System.IO;
using System.Linq;
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

        static void Main(string[] args)
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

            string action;
            if (args != null && args.Any())
            {
                action = args[0];
            }
            else
            {
                Console.WriteLine("Welcome to the Instagram tool!");
                Console.WriteLine("0 - Transfer last media.");
                Console.WriteLine("1 - Apply last metadata.");
                Console.WriteLine("2 - Transfer all media.");
                Console.WriteLine("3 - Apply all metadata.");
                Console.WriteLine("4 - Save media to database.");
                Console.WriteLine("5 - Upload media from database.");
                action = Console.ReadLine();
            }            

            var transferService = serviceProvider.GetService<ITransferService>();

            var sb = new StringBuilder();
            for (var i = 0; i < config.SourceChannels.Length; i++)
            {
                var sourceChannelId = config.SourceChannels[i];
                var destChannelId = config.DestChannels[i];
                logger.LogTrace($"[{sourceChannelId}] => [{destChannelId}]...");

                try
                {
                    if (action == "0")
                    {
                        transferService.TransferMediaLast(sourceChannelId, destChannelId).Wait();
                    }
                    else if (action == "1")
                    {
                        transferService.ApplyMediaMetadataLast(sourceChannelId, destChannelId).Wait();
                    }
                    else if (action == "2")
                    {
                        transferService.TransferMedia(sourceChannelId, destChannelId).Wait();
                    }
                    else if (action == "3")
                    {
                        transferService.ApplyMediaMetadataAll(sourceChannelId, destChannelId).Wait();
                    }
                    else if (action == "4")
                    {
                        transferService.SaveMedia(sourceChannelId, destChannelId).Wait();
                    }
                    else if (action == "5")
                    {
                        transferService.UploadMedia(sourceChannelId, destChannelId).Wait();
                    }
                }
                catch (Exception exc)
                {
                    logger.LogError(exc.Message);
                }

                logger.LogTrace($"[{sourceChannelId}] => [{destChannelId}] completed.{Environment.NewLine}");
                sb.AppendLine($"[https://www.instagram.com/{sourceChannelId}] => [https://www.instagram.com/{destChannelId}]");
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
