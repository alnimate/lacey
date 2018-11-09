using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Cli.Base;
using Lacey.Medusa.Common.Extensions.Base;
using Lacey.Medusa.Youtube.Common.Interfaces;
using Lacey.Medusa.Youtube.Common.Models.About;
using Lacey.Medusa.Youtube.Common.Models.Common;
using Lacey.Medusa.Youtube.Common.Models.Videos;
using Lacey.Medusa.Youtube.Scrap.Base.Models.MediaStreams;
using Lacey.Medusa.Youtube.Scrap.Services.Common;

namespace Lacey.Medusa.Youtube.Scrap.Services.Channels
{
    public sealed class YoutubeChannelScrapProvider : YoutubeScrapService, IYoutubeChannelProvider
    {
        private readonly Cli ffmpegCli;

        private readonly string tempDirectoryPath;
        private readonly string outputDirectoryPath;

        public YoutubeChannelScrapProvider()
        {
            this.ffmpegCli = new Cli("ffmpeg.exe");
            this.tempDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Temp");
            this.outputDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        }

    public async Task<YoutubeChannel> GetYoutubeChannel(string channelId)
        {
            var channel = await this.Youtube.GetChannelAsync(channelId);
            var uploads = await this.Youtube.GetChannelUploadsAsync(channelId);

            var videos = new YoutubeVideos(
                uploads.Select(v => new YoutubeVideo(
                    v.Id,
                    v.Title,
                    v.Description,
                    v.UploadDate.UtcDateTime)).ToArray());

            await this.DownloadVideoAsync(videos.Items.First().VideoId);

            var about = new YoutubeAbout(null);

            return new YoutubeChannel(
                channel.Id, 
                channel.Title,
                videos,
                about);
        }

        private async Task DownloadVideoAsync(string id)
        {
            Console.WriteLine($"Working on video [{id}]...");

            // Get video info
            var video = await this.Youtube.GetVideoAsync(id);
            var cleanTitle = video.Title.Replace(Path.GetInvalidFileNameChars(), '_');
            Console.WriteLine($"{video.Title}");

            // Get best streams
            var streamInfoSet = await this.Youtube.GetVideoMediaStreamInfosAsync(id);
            var videoStreamInfo = streamInfoSet.Video.WithHighestVideoQuality();
            var audioStreamInfo = streamInfoSet.Audio.WithHighestBitrate();

            // Download streams
            Console.WriteLine("Downloading...");
            Directory.CreateDirectory(tempDirectoryPath);
            var videoStreamFileExt = videoStreamInfo.Container.GetFileExtension();
            var videoStreamFilePath = Path.Combine(tempDirectoryPath, $"VID-{Guid.NewGuid()}.{videoStreamFileExt}");
            await this.Youtube.DownloadMediaStreamAsync(videoStreamInfo, videoStreamFilePath);
            var audioStreamFileExt = audioStreamInfo.Container.GetFileExtension();
            var audioStreamFilePath = Path.Combine(tempDirectoryPath, $"AUD-{Guid.NewGuid()}.{audioStreamFileExt}");
            await this.Youtube.DownloadMediaStreamAsync(audioStreamInfo, audioStreamFilePath);

            // Mux streams
            Console.WriteLine("Combining...");
            Directory.CreateDirectory(outputDirectoryPath);
            var outputFilePath = Path.Combine(outputDirectoryPath, $"{cleanTitle}.mp4");
            this.ffmpegCli.SetArguments($"-i \"{videoStreamFilePath}\" -i \"{audioStreamFilePath}\" -shortest \"{outputFilePath}\" -y");
            await ffmpegCli.ExecuteAsync();

            // Delete temp files
            Console.WriteLine("Deleting temp files...");
            File.Delete(videoStreamFilePath);
            File.Delete(audioStreamFilePath);

            Console.WriteLine($"Downloaded video [{id}] to [{outputFilePath}]");
        }
    }
}