using Lacey.Medusa.Youtube.Api.Infrastructure;
using Lacey.Medusa.Youtube.Scrap.Infrastructure;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Download;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Download.Concrete;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Store;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Store.Concrete;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Transfer;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Transfer.Concrete;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Upload;
using Lacey.Medusa.Youtube.Services.Transfer.Services.Upload.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Youtube.Services.Transfer.Infrastructure
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Application services registration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="apiKeyFile"></param>
        /// <returns></returns>
        public static IServiceCollection AddYoutubeTransferServices(
            this IServiceCollection services,
            string apiKeyFile)
        {
            services
//                .AddYoutubeApiServices(apiKeyFile)
                .AddYoutubeScrapServices()
                .AddTransient<IDownloadService, DownloadService>()
                .AddTransient<IStoreService, StoreService>()
                .AddTransient<IUploadService, UploadService>()
                .AddTransient<ITransferService, TransferService>();

            return services;
        }
    }
}