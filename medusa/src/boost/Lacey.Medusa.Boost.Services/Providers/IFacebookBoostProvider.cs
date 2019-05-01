using System.Threading.Tasks;

namespace Lacey.Medusa.Boost.Services.Providers
{
    public interface IFacebookBoostProvider
    {
        Task<string[]> SearchPeopleAsync(string query);
    }
}