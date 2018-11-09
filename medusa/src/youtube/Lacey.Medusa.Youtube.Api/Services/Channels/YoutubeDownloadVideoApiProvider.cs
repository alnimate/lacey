using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Youtube.Api.Services.Auth;
using Lacey.Medusa.Youtube.Api.Services.Common;
using Lacey.Medusa.Youtube.Common.Interfaces;

namespace Lacey.Medusa.Youtube.Api.Services.Channels
{
    public sealed class YoutubeDownloadVideoApiProvider : YoutubeApiService, IYoutubeDownloadVideoProvider
    {
        public YoutubeDownloadVideoApiProvider(IYoutubeAuthProvider youtubeAuthProvider, IMapper mapper) : base(youtubeAuthProvider, mapper)
        {
        }

        public Task DownloadVideo(string videoId)
        {
            throw new System.NotImplementedException();
        }
    }
}