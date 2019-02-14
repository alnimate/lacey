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

        #region Apply metadata

        Task<IResult<bool>> UnArchiveMediaAsync(string mediaId);

        Task<IResult<bool>> UnSaveMediaAsync(string mediaId);

        Task<IResult<InstaMedia>> EditMediaAsync(
            string mediaId,
            string caption,
            InstaLocationShort location = null,
            InstaUserTagUpload[] userTags = null);

        #endregion

        #region Transfer media

        Task<string> DownloadMedia(InstaMedia media, string outputFolder);

        Task<InstaMediaList> GetUserMediaLast(string userName);

        Task<InstaMediaList> GetUserMediaAll(string userName);

        Task<IReadOnlyList<IResult<InstaMedia>>> UploadMedia(InstaMedia media, string outputFolder);

        #endregion
    }
}