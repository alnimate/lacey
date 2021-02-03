using System.Threading.Tasks;

namespace Lacey.Alexa.Common.Shodan.Services
{
    public interface IShodanLoginService
    {
        Task Login();

        bool IsAuthenticated();
    }
}