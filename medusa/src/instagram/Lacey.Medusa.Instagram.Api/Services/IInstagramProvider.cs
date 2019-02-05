using System.Threading.Tasks;
using InstagramApiSharp.Classes.Models;

namespace Lacey.Medusa.Instagram.Api.Services
{
    public interface IInstagramProvider
    {
        #region Media

        Task<InstaMediaList> GetUserMediaAll(string userName);

        Task DownloadMedia(InstaMedia media, string outputFolder);

        #endregion
    }
}