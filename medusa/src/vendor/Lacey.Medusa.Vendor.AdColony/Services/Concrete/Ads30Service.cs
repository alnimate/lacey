using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Core.Extensions;
using Lacey.Medusa.Common.Core.Serializers;
using Lacey.Medusa.Common.Core.Utils;
using Lacey.Medusa.Vendor.AdColony.Extensions;
using Lacey.Medusa.Vendor.AdColony.Models.Ads30.Configure;
using Lacey.Medusa.Vendor.AdColony.Providers;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Vendor.AdColony.Services.Concrete
{
    public class Ads30Service : IAds30Service
    {
        private readonly ILogger logger;

        private readonly Ads30Provider ads30;

        public Ads30Service(ILogger logger)
        {
            this.logger = logger;

            this.ads30 = new Ads30Provider(new BaseClientService.Initializer
                {
                    Serializer = new Json2JsonSerializer()
                });
        }

        public async Task<ConfigureModel> Configure(ConfigureRequestModel req)
        {
            return await ProceedUtils.Proceed(this.logger, async () =>
            {
                var request = this.ads30.Configure.Configure(req).SetDefault();

                var response = await request.ExecuteAsync();
                this.logger.LogTrace(response.GetLog());
                return response;
            });
        }
    }
}