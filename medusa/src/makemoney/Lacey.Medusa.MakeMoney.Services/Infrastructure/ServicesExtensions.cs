﻿using System.IO;
using Lacey.Medusa.Common.Email.Services.Email;
using Lacey.Medusa.MakeMoney.Services.Services;
using Lacey.Medusa.MakeMoney.Services.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.MakeMoney.Services.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddMakeMoneyServices(
            this IServiceCollection services,
            string userSecretsFile,
            string commonSecretsFile,
            bool isSendEmails)
        {
            services
                .AddTransient<IMmStoreService, FileMmStoreService>(
                    provider => new FileMmStoreService(
                        Path.Combine(Path.GetDirectoryName(userSecretsFile), "session.secret")))

                .AddTransient<IMakeMoneyService, MakeMoneyService>(
                    provider => new MakeMoneyService(
                        provider.GetService<ILogger<MakeMoneyService>>(),
                        provider.GetService<IEmailProvider>(),
                        isSendEmails, 
                        userSecretsFile, 
                        commonSecretsFile,
                        provider.GetService<IMmStoreService>()));

            return services;
        }
    }
}