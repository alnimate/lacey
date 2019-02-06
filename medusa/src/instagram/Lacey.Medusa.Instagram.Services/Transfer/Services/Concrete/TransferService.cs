using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Instagram.Api.Services;
using Lacey.Medusa.Instagram.Services.Common.Services;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Instagram.Services.Transfer.Services.Concrete
{
    public sealed class TransferService : InstagramApiService, ITransferService
    {
        private readonly string outputFolder;

        public TransferService(
            IInstagramProvider instagramProvider,
            ILogger<TransferService> logger, 
            string outputFolder) : base(instagramProvider, logger)
        {
            this.outputFolder = outputFolder;
        }

        public async Task TransferAllMedia(string sourceChannelId, string destChannelId)
        {
            var mediaList = await this.InstagramProvider.GetUserMediaAll(sourceChannelId);
            foreach (var media in mediaList.Take(1))
            {
                this.Logger.LogTrace($"Uploading \"{media.Caption?.Text}\"...");
                var results = await this.InstagramProvider.UploadMedia(media, this.outputFolder);
                foreach (var result in results)
                {
                    if (!result.Succeeded)
                    {
                        this.Logger.LogTrace($"{result.Info?.Message}");
                    }
                }

                this.Logger.LogTrace($"\"{media.Caption?.Text}\" uploaded.");
            }
        }
    }
}