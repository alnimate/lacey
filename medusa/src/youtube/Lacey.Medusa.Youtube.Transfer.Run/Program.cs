using System;
using System.IO;
using System.Text;
using Lacey.Medusa.Common.Email.Services.Email;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Lacey.Medusa.Youtube.Transfer.Configuration;
using Lacey.Medusa.Youtube.Transfer.Infrastructure;
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

            logger.LogTrace("Welcome to the YouTube transferring tool!");

            var transferService = serviceProvider.GetService<ITransferService>();

            var sb = new StringBuilder();
            for (var i = 0; i < config.SourceChannels.Length; i++)
            {
                var sourceChannelId = config.SourceChannels[i];
                var destChannelId = config.DestChannels[i];
                try
                {
                    logger.LogTrace($"[{sourceChannelId}] => [{destChannelId}]...");
                    transferService.TransferChannel(
                        sourceChannelId,
                        destChannelId).Wait();
                    logger.LogTrace($"[{sourceChannelId}] => [{destChannelId}] completed.{Environment.NewLine}");
                    sb.AppendLine(
                        $"[https://www.youtube.com/channel/{sourceChannelId}] => [https://www.youtube.com/channel/{destChannelId}]");
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
