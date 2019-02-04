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
            Console.WriteLine("0 - Full Transfer;");
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
                        logger.LogTrace($"[{sourceChannelId}] => [{destChannelId}]...");
                        transferService.Transfer(sourceChannelId, destChannelId).Wait();
                        logger.LogTrace($"[{sourceChannelId}] => [{destChannelId}] completed.{Environment.NewLine}");
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
