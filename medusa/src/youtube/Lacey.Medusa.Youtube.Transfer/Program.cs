using System.IO;
using System.Linq;
using AutoMapper;
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
            var appConfiguration = configuration.GetSection("App").Get<AppConfiguration>();
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
                    appConfiguration.ApiKeyFile,
                    appConfiguration.ClientSecretsFilePath,
                    appConfiguration.UserName,
                    Path.Combine(currentFolder, appConfiguration.TempFolder),
                    Path.Combine(currentFolder, appConfiguration.OutputFolder),
                    Path.Combine(currentFolder, appConfiguration.ConverterFile))
                .BuildServiceProvider();

            //configure console logging
            logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogTrace("Welcome to the YouTube transferring tool!");

            var transferService = serviceProvider.GetService<ITransferService>();

            transferService.TransferChannel(
                appConfiguration.SourceChannels.First(),
                appConfiguration.DestChannels.First()).Wait();

            serviceProvider.Dispose();
        }
    }
}
