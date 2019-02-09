using System.Collections.Generic;
using System.Threading.Tasks;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;

namespace Lacey.Medusa.Instagram.Api.Services
{
    public interface IInstagramProvider
    {
        #region Login

        Task Login();

        #endregion

        #region Media

        Task<string> DownloadMedia(InstaMedia media, string outputFolder);

        Task<InstaMediaList> GetUserMediaLast(string userName);

        Task<InstaMediaList> GetUserMediaAll(string userName);

        Task<IReadOnlyList<IResult<InstaMedia>>> UploadMedia(InstaMedia media, string outputFolder);

        #endregion
    }
}