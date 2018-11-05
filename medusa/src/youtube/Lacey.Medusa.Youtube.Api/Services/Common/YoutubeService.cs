using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Services.Auth;

namespace Lacey.Medusa.Youtube.Api.Services.Common
{
    public abstract class YoutubeService
    {
        internal YouTubeService Youtube { get; }

        protected YoutubeService(IAuthProvider authProvider)
        {
            this.Youtube = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = authProvider.GetApiKey(),
                ApplicationName = GetType().ToString()
            });
        }
    }
}