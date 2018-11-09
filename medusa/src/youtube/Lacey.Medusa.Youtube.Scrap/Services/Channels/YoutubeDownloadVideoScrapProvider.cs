using System;
using System.IO;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Cli.Base;
using Lacey.Medusa.Common.Extensions.Base;
using Lacey.Medusa.Youtube.Common.Interfaces;
using Lacey.Medusa.Youtube.Scrap.Base.Models.MediaStreams;
using Lacey.Medusa.Youtube.Scrap.Services.Common;

namespace Lacey.Medusa.Youtube.Scrap.Services.Channels
{
    public sealed class YoutubeDownloadVideoScrapProvider : YoutubeScrapService, IYoutubeDownloadVideoProvider
    {
        private readonly string tempFolder;
        private readonly string outputFolder;
        private readonly Cli converterCli;

        public YoutubeDownloadVideoScrapProvider(
            string tempFolder, 
            string outputFolder, 
            string converterFilePath)
        {
            this.tempFolder = tempFolder;
            this.outputFolder = outputFolder;
            this.converterCli = new Cli(converterFilePath);
        }

        public async Task DownloadVideo(string videoId)
        {
            Console.WriteLine($"Working on video [{videoId}]...");

            // Get video info
            var video = await this.Youtube.GetVideoAsync(videoId);
            var cleanTitle = video.Title.Replace(Path.GetInvalidFileNameChars(), '_');
            Console.WriteLine($"{video.Title}");

            // Get best streams
            var streamInfoSet = await this.Youtube.GetVideoMediaStreamInfosAsync(videoId);
            var videoStreamInfo = streamInfoSet.Video.WithHighestVideoQuality();
            var audioStreamInfo = streamInfoSet.Audio.WithHighestBitrate();

            // Download streams
            Console.WriteLine("Downloading...");
            Directory.CreateDirectory(tempFolder);
            var videoStreamFileExt = videoStreamInfo.Container.GetFileExtension();
            var videoStreamFilePath = Path.Combine(tempFolder, $"VID-{Guid.NewGuid()}.{videoStreamFileExt}");
            await this.Youtube.DownloadMediaStreamAsync(videoStreamInfo, videoStreamFilePath);
            var audioStreamFileExt = audioStreamInfo.Container.GetFileExtension();
            var audioStreamFilePath = Path.Combine(tempFolder, $"AUD-{Guid.NewGuid()}.{audioStreamFileExt}");
            await this.Youtube.DownloadMediaStreamAsync(audioStreamInfo, audioStreamFilePath);

            // Mux streams
            Console.WriteLine("Combining...");
            Directory.CreateDirectory(outputFolder);
            var outputFilePath = Path.Combine(outputFolder, $"{cleanTitle}.mp4");
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
                Console.WriteLine("Deleting temp files...");
                File.Delete(videoStreamFilePath);
                File.Delete(audioStreamFilePath);
            }

            Console.WriteLine($"Downloaded video [{videoId}] to [{outputFilePath}]");
        }
    }
}