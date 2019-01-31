using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Browser.Browsers;
using Lacey.Medusa.Youtube.Api.Services;
using Lacey.Medusa.Youtube.Services.Common.Services;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Copyright;
using Lacey.Medusa.Youtube.Services.Transfer.Utils;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete
{
    public sealed class CopyrightService : YoutubeAuthClientService, ICopyrightService
    {
        private readonly IYoutubeProvider youtubeProvider;

        private readonly ILogger logger;

        private readonly string outputFolder;

        private readonly IChannelsService channelsService;

        private readonly IVideosService videosService;

        public CopyrightService(
            IYoutubeAuthProvider youtubeAuthProvider,
            IYoutubeProvider youtubeProvider,
            ILogger<CopyrightService> logger,
            string outputFolder,
            IChannelsService channelsService,
            IVideosService videosService) : base(youtubeAuthProvider)
        {
            this.youtubeProvider = youtubeProvider;
            this.logger = logger;
            this.outputFolder = outputFolder;
            this.channelsService = channelsService;
            this.videosService = videosService;
        }

        public async Task<IReadOnlyList<CopyrightNotice>> GetCopyrightNotices(string channelId)
        {
            var notices = new List<CopyrightNotice>();

            using (var browser = new ChromeBrowser())
            {
                var parser = new CopyrightNoticesParser();
                var videosPageSource = browser.GetPageSource("https://www.youtube.com/my_videos_copyright");
                var videoUrls = await parser.ParseVideosCopyright(videosPageSource);

                foreach (var videoUrl in videoUrls)
                {
                    var pageSource = browser.GetPageSource($"https://www.youtube.com/{videoUrl}");
                    var videoId = videoUrl.Replace("/video_copynotice?v=", string.Empty);
                    var copyrightNotices = await parser.ParseCopyrightNotices(videoId, pageSource);
                    if (copyrightNotices != null && copyrightNotices.Any())
                    {
                        notices.AddRange(copyrightNotices);
                    }
                }
            }

            return notices;
        }

        public async Task FixCopyrightIssues(string channelId, IReadOnlyList<CopyrightNotice> notices)
        {
            var currentFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var videosFolder = Path.Combine(currentFolder, "temp");
            var inputFile = new MediaFile { Filename = Path.Combine(videosFolder, "03.mp4") };
            var outputFile = new MediaFile { Filename = Path.Combine(videosFolder, $"{Guid.NewGuid()}.mp4") };

            using (var engine = new Engine(Path.Combine(currentFolder, "ffmpeg.exe")))
            {
                engine.GetMetadata(inputFile);

                var options = new ConversionOptions();

                //// First parameter requests the starting frame to cut the media from.
                //// Second parameter requests how long to cut the video.
                var start = notices[2].Claims[1].Content.MatchStart;
                options.CutMedia(start, start.Add(TimeSpan.FromSeconds(1)));

                engine.Convert(inputFile, outputFile, options);
            }

            //            var channel = await this.channelsService.GetChannelMetadata(channelId);
            var videos = await this.videosService.GetChannelVideos(channelId);

            foreach (var notice in notices)
            {
                string filePath = null;
                try
                {
                    var video = videos.FirstOrDefault(v => v.VideoId == notice.VideoId);
                    if (video == null)
                    {
                        continue;
                    }

                    var videoId = video.OriginalVideoId;
                    this.logger.LogTrace($"Downloading video [{videoId}]...");
                    filePath = await this.youtubeProvider.DownloadVideo(videoId, this.outputFolder);
                    this.logger.LogTrace($"Video [{videoId}] downloaded to [{filePath}]");

//                    var uploadedVideo = await this.youtubeProvider.UploadVideo(channelId, youtubeVideo, filePath);
//                    await this.videosService.Add(channel.Id, videoId, uploadedVideo);
                }
                catch (Exception exc)
                {
                    this.logger.LogError(exc.Message);
                }
//                finally
//                {
//                    if (!string.IsNullOrEmpty(filePath))
//                    {
//                        File.Delete(filePath);
//                    }
//                }
            }
        }
    }
}