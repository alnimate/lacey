using System.Collections.Generic;
using System.Threading.Tasks;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;

namespace Lacey.Medusa.Instagram.Api.Services
{
    public interface IInstagramProvider
    {
        #region Media

        Task<InstaMediaList> GetUserMediaAll(string userName);

        Task<IReadOnlyList<IResult<InstaMedia>>> UploadMedia(InstaMedia media, string outputFolder);

        #endregion
    }
}