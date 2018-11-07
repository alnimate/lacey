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
        /// <returns></returns>
        public static IServiceCollection AddTransferServices(
            this IServiceCollection services)
        {
            services.AddTransient<IDownloadService, DownloadService>();
            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<IUploadService, UploadService>();
            services.AddTransient<ITransferService, TransferService>();

            return services;
        }
    }
}