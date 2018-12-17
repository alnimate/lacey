using System.Threading.Tasks;
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

        public async Task<Copynotice> GetVideoCopynotice(string videoId)
        {
            var copynoticeUrl = $"https://www.youtube.com/video_copynotice?v={videoId}";

            var responce = await this.HttpClient.GetAsync(copynoticeUrl);
            var html = await responce.Content.ReadAsStringAsync();

            return null;
        }
    }
}