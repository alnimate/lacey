using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Upload;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Upload
{
    public interface IUploadService
    {
        Task UploadChannel(UploadChannel channel);
    }
}