using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Core.Serializers;
using Lacey.Medusa.Common.Core.Utils;
using Lacey.Medusa.Vendor.AdColony.Extensions;
using Lacey.Medusa.Vendor.AdColony.Models.Events3.Rewardv4vc;
using Lacey.Medusa.Vendor.AdColony.Providers;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Vendor.AdColony.Services.Concrete
{
    public sealed class Events3Service : IEvents3Service
    {
        private readonly ILogger logger;

        private readonly Events3Provider events3;

        public Events3Service(ILogger logger)
        {
            this.logger = logger;

            this.events3 = new Events3Provider(new BaseClientService.Initializer
            {
                Serializer = new Json2JsonSerializer()
            });
        }

        public async Task<Rewardv4VcModel> Rewardv4Vc(string pl, Rewardv4VcRequestModel req)
        {
            return await ProceedUtils.Proceed(this.logger, async () =>
            {
                var request = this.events3.Rewardv4Vc.Rewardv4Vc(pl, req).SetDefault();
                return await request.ExecuteAsync();
            });
        }
    }
}