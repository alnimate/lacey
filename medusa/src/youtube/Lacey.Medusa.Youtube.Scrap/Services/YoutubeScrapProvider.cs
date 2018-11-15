using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Cli.Base;
using Lacey.Medusa.Common.Extensions.Base;
using Lacey.Medusa.Youtube.Scrap.Base;
using Lacey.Medusa.Youtube.Scrap.Base.Models;
using Lacey.Medusa.Youtube.Scrap.Base.Models.MediaStreams;
using Lacey.Medusa.Youtube.Scrap.Utils;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Scrap.Services
{
    public sealed class YoutubeScrapProvider
    {
        private readonly IYoutubeClient youtube;
        private readonly ILogger logger;

        private readonly string tempFolder;
        private readonly string outputFolder;
        private readonly Cli converterCli;

        public YoutubeScrapProvider(
            IYoutubeClient youtube,
            ILogger<YoutubeScrapProvider> logger,
            string tempFolder,
            string outputFolder,
            string converterFilePath)
        {
            this.youtube = youtube;
            this.logger = logger;
            this.tempFolder = tempFolder;
            this.outputFolder = outputFolder;
            this.converterCli = new Cli(converterFilePath);
        }

        public async Task<Channel> GetChannel(string channelId)
        {
            return await this.youtube.GetChannelAsync(channelId);
        }

        public async Task<IReadOnlyList<Video>> GetChannelVideos(string channelId)
        {
            return await this.youtube.GetChannelUploadsAsync(channelId);
        }


        public async Task<string> DownloadVideo(string videoId)
        {
            this.logger.LogTrace($"Working on video [{videoId}]...");

            // Get video info
            var video = await this.youtube.GetVideoAsync(videoId);
            var cleanTitle = video.Title.Replace(Path.GetInvalidFileNameChars(), '_');
            this.logger.LogTrace($"{video.Title}");

            // Get best streams
            var streamInfoSet = await this.youtube.GetVideoMediaStreamInfosAsync(videoId);
            var videoStreamInfo = streamInfoSet.Video.WithHighestVideoQuality();
            var audioStreamInfo = streamInfoSet.Audio.WithHighestBitrate();

            // Download streams
            this.logger.LogTrace("Downloading...");
            Directory.CreateDirectory(tempFolder);
            var videoStreamFileExt = videoStreamInfo.Container.GetFileExtension();
            var videoStreamFilePath = Path.Combine(tempFolder, $"VID-{Guid.NewGuid()}.{videoStreamFileExt}");
            using (var progress = new ProgressBar())
                await this.youtube.DownloadMediaStreamAsync(videoStreamInfo, videoStreamFilePath, progress);
            var audioStreamFileExt = audioStreamInfo.Container.GetFileExtension();
            var audioStreamFilePath = Path.Combine(tempFolder, $"AUD-{Guid.NewGuid()}.{audioStreamFileExt}");
            using (var progress = new ProgressBar())
                await this.youtube.DownloadMediaStreamAsync(audioStreamInfo, audioStreamFilePath, progress);

            Directory.CreateDirectory(outputFolder);
            var outputFilePath = Path.Combine(outputFolder, $"{cleanTitle}.mp4");

            using (var stream = File.OpenRead(videoStreamFilePath))
            {
                if (stream.Length > 30 * 1024 * 1024)
                {
                    // Delete temp files
                    this.logger.LogTrace("Deleting temp files...");
                    stream.Close();
                    File.Move(videoStreamFilePath, outputFilePath);
                    File.Delete(audioStreamFilePath);
                    this.logger.LogTrace($"Downloaded video [{videoId}] to [{outputFilePath}]");
                    return outputFilePath;
                }
            }

            // Mux streams
            this.logger.LogTrace("Combining...");
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
                this.logger.LogTrace("Deleting temp files...");
                File.Delete(videoStreamFilePath);
                File.Delete(audioStreamFilePath);
            }

            this.logger.LogTrace($"Downloaded video [{videoId}] to [{outputFilePath}]");
            return outputFilePath;
        }
    }
}