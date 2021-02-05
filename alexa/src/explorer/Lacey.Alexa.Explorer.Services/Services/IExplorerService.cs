using System.Threading.Tasks;

namespace Lacey.Alexa.Explorer.Services.Services
{
    public interface IExplorerService
    {
        Task FindVulnerableHosts();

        Task<string[]> QueryHosts(string query);

        Task ExploitHost(string host);
    }
}