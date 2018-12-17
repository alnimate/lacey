using System.Collections.Generic;
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Youtube.Api.Services;

namespace Lacey.Medusa.Youtube.Services.Common.Services
{
    public abstract class YoutubeAuthClientService : BaseClientService
    {
        protected YoutubeAuthClientService(
            IYoutubeAuthProvider youtubeAuthProvider) : base(
            new Initializer
            {
                HttpClientInitializer = youtubeAuthProvider.GetUserCredentials().Result,
                ApplicationName = "YoutubeAuthClientService"
            })
        {
        }

        public override IList<string> Features => new string[0];

        public override string Name => "youtube";

        public override string BaseUri => "https://www.googleapis.com/youtube/v3/";

        public override string BasePath => "youtube/v3/";
    }
}