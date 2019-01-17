using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Browser.Browsers;
using Lacey.Medusa.Youtube.Api.Services;
using Lacey.Medusa.Youtube.Services.Common.Services;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Copyright;
using Lacey.Medusa.Youtube.Services.Transfer.Utils;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete
{
    public sealed class CopyrightService : YoutubeAuthClientService, ICopyrightService
    {
        public CopyrightService(IYoutubeAuthProvider youtubeAuthProvider) : base(youtubeAuthProvider)
        {
        }

        public async Task<IReadOnlyList<CopyrightNotice>> GetCopyrightNotices(string channelId)
        {
            var notices = new List<CopyrightNotice>();

            using (var browser = new ChromeBrowser())
            {
//                var videoUrls = new[]
//                {
//                    "/video_copynotice?v=dJblZLEYPXE"
//                };

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
    }
}