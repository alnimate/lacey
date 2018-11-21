using Lacey.Medusa.Youtube.Api.Infrastructure;
using Lacey.Medusa.Youtube.Services.Transfer.Services;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Services.Transfer.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddYoutubeTransferServices(
            this IServiceCollection services,
            string clientSecretsFilePath,
            string userName,
            string outputFolder)
        {
            services
                .AddYoutubeServices(
                    clientSecretsFilePath,
                    userName,
                    outputFolder)

                .AddTransient<ITransferService, TransferService>()
                .AddTransient<IClearService, ClearService>();

            return services;
        }
    }
}