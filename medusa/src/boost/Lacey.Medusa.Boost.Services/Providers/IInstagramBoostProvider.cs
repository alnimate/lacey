using System.Collections.Generic;
using System.Threading.Tasks;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;

namespace Lacey.Medusa.Boost.Services.Providers
{
    public interface IInstagramBoostProvider
    {
        #region Login

        Task Login();

        #endregion

        #region Search

        Task<IResult<InstaDiscoverSearchResult>> SearchPeopleAsync(string query, int count = 50);

        Task<IResult<InstaHashtagSearch>> SearchHashtagAsync(
            string query,
            IEnumerable<long> excludeList = null,
            string rankToken = null);

        #endregion

        #region Media

        Task<InstaMediaList> GetLastMedia(string userName);

        Task<IResult<InstaComment>> CommentMediaAsync(string mediaId, string text);

        #endregion
    }
}