using System;
using System.IO;
using System.Linq;
using System.Net;
using Lacey.Alexa.Explorer.Run.Configuration;
using Lacey.Alexa.Explorer.Run.Infrastructure;
using Lacey.Alexa.Explorer.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Alexa.Explorer.Run
{
    class Program
    {
        private static ILogger<Program> _logger;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var config = configuration.GetSection("App").Get<AppConfiguration>();

            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddLogging(logBuilder =>
                    logBuilder
                        .AddLog4Net()
                        .SetMinimumLevel(LogLevel.Trace))
                .AddAppServices(config)
                .BuildServiceProvider();

            //configure console logging
            _logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            string action;
            if (args != null && args.Any())
            {
                action = args[0];
            }
            else
            {
                Console.WriteLine("Welcome to the Explorer!");
                Console.WriteLine("0 - Find Vulnerable Hosts");
                Console.WriteLine("1 - Query Hosts");
                Console.WriteLine("2 - Exploit Host");
                action = Console.ReadLine();
            }

            var service = serviceProvider.GetService<IExplorerService>();

            try
            {
                if (action == "0")
                {
                    service?.FindVulnerableHosts().Wait();
                }
                else if (action == "1")
                {
                    Console.Write("Query: ");
                    var query = Console.ReadLine();
                    var hosts = service?.QueryHosts(query).Result;
                    if (hosts != null)
                    {
                        foreach (var host in hosts)
                        {
                            Console.WriteLine(host);
                        }
                    }
                }
                else if (action == "2")
                {
                    string host;
                    while (true)
                    {
                        Console.Write("Host Address: ");
                        host = Console.ReadLine();
                        if (IPAddress.TryParse(host, out _))
                        {
                            break;
                        }
                    }
                    service?.ExploitHost(host).Wait();
                }
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
            }

            serviceProvider.Dispose();
        }
    }
}
