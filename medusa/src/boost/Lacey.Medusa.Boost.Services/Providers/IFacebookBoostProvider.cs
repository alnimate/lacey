using System.Threading.Tasks;

namespace Lacey.Medusa.Boost.Services.Providers
{
    public interface IFacebookBoostProvider
    {
        Task<object> SearchPeopleAsync(string query);
    }
}