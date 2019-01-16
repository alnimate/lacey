using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Browser.Browsers;
using Lacey.Medusa.Youtube.Api.Services;
using Lacey.Medusa.Youtube.Services.Common.Services;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Copyright;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete
{
    public sealed class CopyrightService : YoutubeAuthClientService, ICopyrightService
    {
        public CopyrightService(IYoutubeAuthProvider youtubeAuthProvider) : base(youtubeAuthProvider)
        {
        }

        public async Task<IReadOnlyList<CopyrightNotice>> GetCopyrightNotices(string channelId)
        {
            var copyrightNotices = new List<CopyrightNotice>();

            using (var browser = new ChromeBrowser())
            {
                var videoIds = new[]
                {
                    "dJblZLEYPXE",
                    "FWxgbcGF6hg",
                    "N5E23EcuNmQ"
                };

                foreach (var videoId in videoIds)
                {
                    var pageSource = browser.GetPageSource($"https://www.youtube.com/video_copynotice?v={videoId}");
                }
            }

            return copyrightNotices;
        }
    }
}