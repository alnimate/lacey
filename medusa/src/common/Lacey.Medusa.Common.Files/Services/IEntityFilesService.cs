using System.Threading.Tasks;
using Lacey.Medusa.Common.Files.Models;

namespace Lacey.Medusa.Common.Files.Services
{
    public interface IEntityFilesService
    {
        Task<UploadedFiles> Upload(UploadFiles uploadFiles);

        Task<BindedToEntity> Bind(BindToEntity bindToEntity);

        Task<DownloadFileResult> Download(DownloadFile downloadFile);
    }
}