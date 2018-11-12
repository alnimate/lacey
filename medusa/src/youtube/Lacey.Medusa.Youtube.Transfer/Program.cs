using System;
using System.IO;
using System.Linq;
using AutoMapper;
using Lacey.Medusa.Common.Email.Services.Email;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Lacey.Medusa.Youtube.Transfer.Configuration;
using Lacey.Medusa.Youtube.Transfer.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Transfer
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

            var currentFolder = Directory.GetCurrentDirectory();
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging(logBuilder => 
                    logBuilder
                        .AddLog4Net()
                        .SetMinimumLevel(LogLevel.Trace))
                .AddAutoMapper()
                .AddAppServices(
                    connectionString, 
                    config.ApiKeyFile,
                    config.ClientSecretsFilePath,
                    config.UserName,
                    Path.Combine(currentFolder, config.TempFolder),
                    Path.Combine(currentFolder, config.OutputFolder),
                    Path.Combine(currentFolder, config.ConverterFile),
                    config.Email.SmtpHost,
                    config.Email.SmtpPort,
                    config.Email.SmtpUsername,
                    Path.Combine(currentFolder, config.Email.SmtpSecretFile))
                .BuildServiceProvider();

            //configure console logging
            logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogTrace("Welcome to the YouTube transferring tool!");

            var transferService = serviceProvider.GetService<ITransferService>();

            var sourceChannelId = config.SourceChannels.First();
            var destChannelId = config.DestChannels.First();
            try
            {
                transferService.TransferChannel(
                    sourceChannelId,
                    destChannelId).Wait();
            }
            catch (Exception exc)
            {
                logger.LogError(exc.Message);
            }
            finally
            {
                var emailService = serviceProvider.GetService<IEmailProvider>();
                emailService.Send(
                    config.Email.From,
                    config.Email.To,
                    "YouTube Transfer Completed.",
                    $"Channel https://www.youtube.com/channel/{sourceChannelId} was transferred to https://www.youtube.com/channel/{destChannelId}.",
                    true,
                    new []
                    {
                        Path.Combine(currentFolder, config.Logs.LogFile)
                    });

                serviceProvider.Dispose();
                logger.LogTrace($"Transferring completed!{Environment.NewLine}");
            }
        }
    }
}
