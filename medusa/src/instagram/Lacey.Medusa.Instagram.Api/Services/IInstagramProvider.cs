using System.Threading.Tasks;
using InstagramApiSharp.Classes.Models;

namespace Lacey.Medusa.Instagram.Api.Services
{
    public interface IInstagramProvider
    {
        Task<InstaMediaList> GetUserMediaAsync(string userName);

        Task DownloadMedia(InstaMedia media, string outputFolder);
    }
}