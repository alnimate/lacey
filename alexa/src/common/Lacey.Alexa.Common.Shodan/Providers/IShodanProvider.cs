using System;
using System.Threading.Tasks;
using Shodan.Net;

namespace Lacey.Alexa.Common.Shodan.Providers
{
    public interface IShodanProvider
    {
        Task<object> SearchHosts(
            Action<QueryGenerator> query,
            Action<FacetGenerator> facet = null,
            int page = 1,
            bool minify = true);
    }
}