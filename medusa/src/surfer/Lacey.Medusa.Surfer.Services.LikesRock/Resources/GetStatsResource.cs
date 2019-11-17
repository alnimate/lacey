using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetStats;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Resources
{
    public sealed class GetStatsResource : LrResource
    {
        public GetStatsResource(IClientService service) : base(service)
        {
        }

        public GetStatsRequest GetStats(string userAccessToken, string userLang, string v)
        {
            return new GetStatsRequest(this.Service, userAccessToken, userLang, v);
        }

        public sealed class GetStatsRequest : LrRequest<GetStatsResponseModel>
        {
            public GetStatsRequest(
                IClientService service,
                string userAccessToken,
                string userLang,
                string v) : base(service)
            {
                UserAccessToken = userAccessToken;
                UserLang = userLang;
                V = v;

                this.RequestParameters.Add("user_access_token", new Parameter
                {
                    Name = "user_access_token",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("user_lang", new Parameter
                {
                    Name = "user_lang",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("v", new Parameter
                {
                    Name = "v",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });
            }

            public override string RestPath => "get_stats.php";

            public override string HttpMethod => HttpConsts.Get;

            [RequestParameter("user_access_token", RequestParameterType.Query)]
            public string UserAccessToken { get; private set; }

            [RequestParameter("user_lang", RequestParameterType.Query)]
            public string UserLang { get; private set; }

            [RequestParameter("v", RequestParameterType.Query)]
            public string V { get; private set; }
        }
    }
}