using System.Collections.Generic;
using System.Threading.Tasks;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;

namespace Lacey.Medusa.Boost.Services.Providers
{
    public interface IInstagramBoostProvider
    {
        Task Login();

        Task<IResult<InstaHashtagSearch>> SearchHashtagAsync(
            string query,
            IEnumerable<long> excludeList = null,
            string rankToken = null);
    }
}