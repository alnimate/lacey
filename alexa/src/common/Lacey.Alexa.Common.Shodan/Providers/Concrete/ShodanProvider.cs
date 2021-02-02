using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shodan.Net;

namespace Lacey.Alexa.Common.Shodan.Providers.Concrete
{
    public sealed class ShodanProvider : IShodanProvider
    {
        private readonly ILogger _logger;

        private readonly ShodanClient _client;

        public ShodanProvider(
            IShodanAuthProvider authProvider,
            ILogger logger)
        {
            _logger = logger;
            _client = new ShodanClient(authProvider.GetApiKey());
        }

        public async Task<object> SearchHosts(
            Action<QueryGenerator> query,
            Action<FacetGenerator> facet = null,
            int page = 1,
            bool minify = true)
        {
            return await _client.SearchHosts(query, facet, page, minify);
        }
    }
}