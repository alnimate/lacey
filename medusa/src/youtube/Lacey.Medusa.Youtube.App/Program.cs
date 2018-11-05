using System.IO;
using Lacey.Medusa.Common.DI.Infrastructure;
using Lacey.Medusa.Youtube.Api.Services.Videos;
using Lacey.Medusa.Youtube.App.Configuration;
using Lacey.Medusa.Youtube.App.Infrastructure;
using Microsoft.Extensions.Configuration;

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

            DependencyInjectionUtils.Initialize();

            var videosService = ManualDependencyResolver.Get<IVideosService>();
            var videos = videosService.GetChannelVideos("UC7hHqT2-4xadNgoGOox5A4Q");
        }
    }
}
