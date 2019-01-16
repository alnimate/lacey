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
                var videoIds = new[]
                {
                    "dJblZLEYPXE",
//                    "FWxgbcGF6hg",
//                    "N5E23EcuNmQ"
                };

                var parser = new CopyrightNoticesParser();
                foreach (var videoId in videoIds)
                {
                    var pageSource = browser.GetPageSource($"https://www.youtube.com/video_copynotice?v={videoId}");
                    var copyrightNotices = await parser.ParseCopyrightNotices(pageSource);
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