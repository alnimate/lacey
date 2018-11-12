using System;
using System.IO;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Common.Models.Videos;
using Lacey.Medusa.Youtube.Common.Video.Base.Core;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Common.Services.Concrete
{
    public sealed class YoutubeDownloadVideoProvider : IYoutubeDownloadVideoProvider
    {
        private readonly ILogger logger;

        private readonly string outputFolder;

        public YoutubeDownloadVideoProvider(
            ILogger<YoutubeDownloadVideoProvider> logger, 
            string outputFolder)
        {
            this.logger = logger;
            this.outputFolder = outputFolder;
        }

        public async Task<YoutubeVideoFile> DownloadVideo(string videoId)
        {
            this.logger.LogTrace($"Working on video [{videoId}]...");
            using (var service = Client.For(YouTube.Default))
            {
                this.logger.LogTrace("Downloading...");

                var video = service.GetVideo("https://youtube.com/watch?v=" + videoId);

                Directory.CreateDirectory(this.outputFolder);
                var outputFilePath = Path.Combine(this.outputFolder, 
                    $"VID-{Guid.NewGuid()}{video.FileExtension}");
                File.WriteAllBytes(outputFilePath, video.GetBytes());
                this.logger.LogTrace($"Downloaded video [{videoId}] to [{outputFilePath}]");
                return new YoutubeVideoFile(outputFilePath);
            }
        }
    }
}