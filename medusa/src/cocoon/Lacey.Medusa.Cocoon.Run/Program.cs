using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Lacey.Medusa.Cocoon.Run.Configuration;
using Lacey.Medusa.Cocoon.Run.Infrastructure;
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
                const string fileName = "a3b4eaeb-82fa-4988-9837-c84e57f513d3.mp4";
                var videoRes = resources.First(r => r.Contains("video.mp4"));
                var tempFolder = Path.GetTempPath();
                var filePath = Path.Combine(tempFolder, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(videoRes))
                using (var file = File.Create(filePath, (int) stream.Length))
                {
                    stream.CopyTo(file);
                }
                var p = new Process
                {
                    StartInfo = new ProcessStartInfo(filePath)
                    {
                        UseShellExecute = true
                    }
                };
                p.Start();
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
