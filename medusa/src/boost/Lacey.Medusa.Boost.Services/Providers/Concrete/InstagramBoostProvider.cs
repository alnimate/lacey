using System.Collections.Generic;
using System.Threading.Tasks;
using InstagramApiSharp;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;
using Lacey.Medusa.Instagram.Api.Services;
using Lacey.Medusa.Instagram.Api.Services.Concrete;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Boost.Services.Providers.Concrete
{
    public sealed class InstagramBoostProvider : InstagramProvider, IInstagramBoostProvider
    {
        #region Properties/Constructors

        private readonly ILogger logger;

        public InstagramBoostProvider(
            IInstagramAuthProvider instagramAuthProvider,
            ILogger<InstagramBoostProvider> logger)
            : base(instagramAuthProvider, logger)
        {
            this.logger = logger;
        }

        #endregion

        #region Search

        public async Task<IResult<InstaDiscoverSearchResult>> SearchPeopleAsync(string query, int count = 50)
        {
            return await this.Instagram.DiscoverProcessor.SearchPeopleAsync(query, count);
        }

        public async Task<IResult<InstaHashtagSearch>> SearchHashtagAsync(
            string query,
            IEnumerable<long> excludeList = null,
            string rankToken = null)
        {
            return await this.Instagram.HashtagProcessor.SearchHashtagAsync(query, excludeList, rankToken);
        }

        #endregion

        #region Media

        public async Task<IResult<InstaComment>> CommentMediaAsync(string mediaId, string text)
        {
            return await this.Instagram.CommentProcessor.CommentMediaAsync(mediaId, text);
        }

        public async Task<InstaMediaList> GetLastMedia(string userName)
        {
            var userMedia = await this.Instagram.UserProcessor.GetUserMediaAsync(
                userName, PaginationParameters.MaxPagesToLoad(1));

            return userMedia.Value;
        }

        #endregion
    }
}