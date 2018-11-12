using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Common.Cli.Base;
using Lacey.Medusa.Common.Extensions.Base;
using Lacey.Medusa.Youtube.Common.Models.Videos;
using Lacey.Medusa.Youtube.Common.Services;
using Lacey.Medusa.Youtube.Scrap.Base.Models.MediaStreams;
using Lacey.Medusa.Youtube.Scrap.Services.Common;
using Lacey.Medusa.Youtube.Scrap.Utils;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Scrap.Services.Channels
{
    public sealed class YoutubeDownloadVideoScrapProvider : YoutubeScrapService, IYoutubeDownloadVideoProvider
    {
        private readonly string tempFolder;
        private readonly string outputFolder;
        private readonly Cli converterCli;

        public YoutubeDownloadVideoScrapProvider(
            IMapper mapper,
            ILogger<YoutubeDownloadVideoScrapProvider> logger,
            string tempFolder, 
            string outputFolder, 
            string converterFilePath)
            : base(mapper, logger)
        {
            this.tempFolder = tempFolder;
            this.outputFolder = outputFolder;
            this.converterCli = new Cli(converterFilePath);
        }

        public async Task<YoutubeVideoFile> DownloadVideo(string videoId)
        {
            this.Logger.LogTrace($"Working on video [{videoId}]...");

            // Get video info
            var video = await this.Youtube.GetVideoAsync(videoId);
            var cleanTitle = video.Title.Replace(Path.GetInvalidFileNameChars(), '_');
            this.Logger.LogTrace($"{video.Title}");

            // Get best streams
            var streamInfoSet = await this.Youtube.GetVideoMediaStreamInfosAsync(videoId);
            var videoStreamInfo = streamInfoSet.Video.WithHighestVideoQuality();
            var audioStreamInfo = streamInfoSet.Audio.WithHighestBitrate();

            // Download streams
            this.Logger.LogTrace("Downloading...");
            Directory.CreateDirectory(tempFolder);
            var videoStreamFileExt = videoStreamInfo.Container.GetFileExtension();
            var videoStreamFilePath = Path.Combine(tempFolder, $"VID-{Guid.NewGuid()}.{videoStreamFileExt}");
            using (var progress = new ProgressBar())
                await this.Youtube.DownloadMediaStreamAsync(videoStreamInfo, videoStreamFilePath, progress);
            var audioStreamFileExt = audioStreamInfo.Container.GetFileExtension();
            var audioStreamFilePath = Path.Combine(tempFolder, $"AUD-{Guid.NewGuid()}.{audioStreamFileExt}");
            using (var progress = new ProgressBar())
                await this.Youtube.DownloadMediaStreamAsync(audioStreamInfo, audioStreamFilePath, progress);

            Directory.CreateDirectory(outputFolder);
            var outputFilePath = Path.Combine(outputFolder, $"{cleanTitle}.mp4");

            using (var stream = File.OpenRead(videoStreamFilePath))
            {
                if (stream.Length > 30 * 1024 * 1024)
                {
                    // Delete temp files
                    this.Logger.LogTrace("Deleting temp files...");
                    stream.Close();
                    File.Move(videoStreamFilePath, outputFilePath);
                    File.Delete(audioStreamFilePath);
                    this.Logger.LogTrace($"Downloaded video [{videoId}] to [{outputFilePath}]");
                    return new YoutubeVideoFile(outputFilePath);
                }
            }

            // Mux streams
            this.Logger.LogTrace("Combining...");
            this.converterCli.SetArguments($"-i \"{videoStreamFilePath}\" -i \"{audioStreamFilePath}\" -shortest \"{outputFilePath}\" -y");
            try
            {
                await converterCli.ExecuteAsync();
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                // Delete temp files
                this.Logger.LogTrace("Deleting temp files...");
                File.Delete(videoStreamFilePath);
                File.Delete(audioStreamFilePath);
            }

            this.Logger.LogTrace($"Downloaded video [{videoId}] to [{outputFilePath}]");
            return new YoutubeVideoFile(outputFilePath);
        }
    }
}