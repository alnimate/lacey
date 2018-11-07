using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Services.Auth;

namespace Lacey.Medusa.Youtube.Api.Services.Common
{
    public abstract class YoutubeService
    {
        public YouTubeService Youtube { get; }

        protected YoutubeService(IYoutubeAuthProvider youtubeAuthProvider)
        {
            this.Youtube = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = youtubeAuthProvider.GetApiKey(),
                ApplicationName = GetType().ToString()
            });
        }
    }
}