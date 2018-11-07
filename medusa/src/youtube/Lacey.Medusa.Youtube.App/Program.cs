using System.IO;
using System.Linq;
using AutoMapper;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Download;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Store;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Upload;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Transfer;
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

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddAutoMapper()
                .AddAppServices(connectionString, appConfiguration.ApiKeyFile)
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            var transferService = serviceProvider.GetService<ITransferService>();
            transferService.OnDownloadChannel += OnDownloadChannel;
            transferService.OnStoreChannel += OnStoreChannel;
            transferService.OnUploadChannel += OnUploadChannel;

            transferService.TransferChannel(
                appConfiguration.SourceChannels.First(),
                appConfiguration.DestChannels.First()).Wait();
        }

        private static void OnDownloadChannel(DownloadChannel channel)
        {
            logger.LogTrace($"Channel {channel.Channel.ChannelId} loaded.");
        }

        private static void OnStoreChannel(StoreChannel channel)
        {
        }

        private static void OnUploadChannel(UploadChannel channel)
        {
        }
    }
}
