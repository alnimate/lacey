using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Browser.Browsers;
using Lacey.Medusa.Youtube.Api.Services;
using Lacey.Medusa.Youtube.Services.Common.Services;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Copyright;
using Lacey.Medusa.Youtube.Services.Transfer.Utils;
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
//            var channel = await this.channelsService.GetChannelMetadata(channelId);
            var videos = await this.youtubeProvider.GetVideos(channelId);

            foreach (var video in videos)
            {
                if (notices.All(n => n.VideoId != video.Id))
                {
                    continue;
                }

                string filePath = null;
                try
                {
                    this.logger.LogTrace($"Downloading video [{video.Id}]...");
                    filePath = await this.youtubeProvider.DownloadVideo(video.Id, this.outputFolder);
                    this.logger.LogTrace($"Video [{video.Id}] downloaded to [{filePath}]");

//                    var uploadedVideo = await this.youtubeProvider.UploadVideo(channelId, video, filePath);
//                    await this.videosService.Add(channel.Id, video.Id, uploadedVideo);
                }
                catch (Exception exc)
                {
                    this.logger.LogError(exc.Message);
                }
                finally
                {
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
            }
        }
    }
}