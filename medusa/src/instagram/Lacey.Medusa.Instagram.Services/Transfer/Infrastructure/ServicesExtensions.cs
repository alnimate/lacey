using Lacey.Medusa.Instagram.Services.Transfer.Services;
using Lacey.Medusa.Instagram.Services.Transfer.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Instagram.Services.Transfer.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddInstagramTransferServices(
            this IServiceCollection services,
            string clientSecretsFilePath,
            string userName,
            string outputFolder,
            string connectionString)
        {
            services.AddTransient<ITransferService, TransferService>(
                provider => new TransferService(
                    provider.GetService<ILogger<TransferService>>(),
                    outputFolder));

            return services;
        }
    }
}