using System.Threading.Tasks;

namespace Lacey.Alexa.Common.Shodan.Services
{
    public interface IShodanService
    {
        Task<string[]> GetHosts(string query);
    }
}