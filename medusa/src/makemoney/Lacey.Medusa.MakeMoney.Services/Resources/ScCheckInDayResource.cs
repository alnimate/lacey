using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Core.Api;
using Lacey.Medusa.MakeMoney.Services.Models.ScCheckInDay;

namespace Lacey.Medusa.MakeMoney.Services.Resources
{
    public sealed class ScCheckInDayResource : ApiResource
    {
        public ScCheckInDayResource(IClientService service) : base(service)
        {
        }

        public ScCheckInDayApiRequest ScCheckInDay(ScCheckInDayRequest request)
        {
            return new ScCheckInDayApiRequest(this.Service, request);
        }

        public sealed class ScCheckInDayApiRequest : ApiRequest<ScCheckInDayResponse>
        {
            private readonly ScCheckInDayRequest body;

            public ScCheckInDayApiRequest(
                IClientService service,
                ScCheckInDayRequest request) : base(service)
            {
                this.body = request;
            }

            public override string RestPath => "SC_CheckInDay";

            public override string HttpMethod => HttpConsts.Post;

            protected override object GetBody()
            {
                return this.body;
            }
        }
    }
}