using System.Threading.Tasks;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Google.Api.Services.Concrete
{
    public class GoogleProvider : IGoogleProvider
    {
        #region properties/constructors

        private readonly IGoogleAuthProvider googleAuthProvider;

        private readonly ILogger logger;

        public GoogleProvider(
            IGoogleAuthProvider googleAuthProvider,
            ILogger<GoogleProvider> logger)
        {
            this.googleAuthProvider = googleAuthProvider;
            this.logger = logger;

            this.Google = new CustomsearchService(new BaseClientService.Initializer
            {
                ApiKey = googleAuthProvider.GetApiKey(),
                ApplicationName = GetType().ToString()
            });
        }

        protected CustomsearchService Google { get; }

        #endregion

        #region search

        public async Task<Search> Search(string query)
        {
            var request = this.Google.Cse.List(query);
            request.Cx = this.googleAuthProvider.GetCx();
            var result = await request.ExecuteAsync();

            return result;
        }

        #endregion
    }
}