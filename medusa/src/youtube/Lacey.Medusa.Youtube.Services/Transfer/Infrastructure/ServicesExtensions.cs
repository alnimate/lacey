﻿using Lacey.Medusa.Youtube.Api.Infrastructure;
using Lacey.Medusa.Youtube.Scrap.Infrastructure;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Services.Transfer.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddYoutubeTransferServices(
            this IServiceCollection services,
            string apiKeyFile,
            string tempFolder,
            string outputFolder,
            string converterFilePath)
        {
            services
                .AddYoutubeApiServices(apiKeyFile)
                .AddYoutubeScrapServices(
                    tempFolder,
                    outputFolder,
                    converterFilePath)

                .AddTransient<ITransferService, TransferService>();

            return services;
        }
    }
}