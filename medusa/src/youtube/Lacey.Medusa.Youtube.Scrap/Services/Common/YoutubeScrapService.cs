using Lacey.Medusa.Youtube.Scrap.Base;

namespace Lacey.Medusa.Youtube.Scrap.Services.Common
{
    public abstract class YoutubeScrapService
    {
        internal IYoutubeClient Youtube { get; }

        protected YoutubeScrapService()
        {
            Youtube = new YoutubeClient();
        }
    }
}