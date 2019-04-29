using System.Threading.Tasks;
using Google.Apis.Customsearch.v1.Data;

namespace Lacey.Medusa.Google.Api.Services
{
    public interface IGoogleProvider
    {
        Task<Search> Search(string query);
    }
}