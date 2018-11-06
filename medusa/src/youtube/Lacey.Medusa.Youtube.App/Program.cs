using System.IO;
using System.Linq;
using AutoMapper;
using Lacey.Medusa.Common.Dal.Infrastructure;
using Lacey.Medusa.Youtube.App.Configuration;
using Lacey.Medusa.Youtube.App.Infrastructure;
using Lacey.Medusa.Youtube.Dal.Infrastructure;
using Lacey.Medusa.Youtube.Services.Api.Services.Videos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.App
{
    class Program
    {
        static void Main(string[] args)
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
                .AddEntityFramework<YoutubeSqlServerDbContext>(connectionString)
                .AddAppServices(connectionString, appConfiguration.ApiKeyFile)
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");


            var videosService = serviceProvider.GetService<IYoutubeVideosService>();
            var videos = videosService.GetChannelVideos(appConfiguration.ChannelsForImport.First());
        }
    }
}
