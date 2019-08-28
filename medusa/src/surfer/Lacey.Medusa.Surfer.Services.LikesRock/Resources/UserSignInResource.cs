using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Resources
{
    public sealed class UserSignInResource : LikesRockResource
    {
        public UserSignInResource(IClientService service) : base(service)
        {
        }

        public UserSignInRequest SignIn(string userLang, string clientVersion)
        {
            return new UserSignInRequest(this.Service, userLang, clientVersion);
        }

        public sealed class UserSignInRequest : LikesRockRequest<string>
        {
            public UserSignInRequest(
                IClientService service, 
                string userLang, 
                string clientVersion) : base(service)
            {
                UserLang = userLang;
                ClientVersion = clientVersion;

                this.RequestParameters.Add("user_lang", new Parameter
                {
                    Name = "user_lang",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("client_version", new Parameter
                {
                    Name = "client_version",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });
            }

            public override string RestPath => "user_sighin.php";

            public override string HttpMethod => HttpConsts.Get;

            [RequestParameter("user_lang", RequestParameterType.Query)]
            public string UserLang { get; private set; }

            [RequestParameter("client_version", RequestParameterType.Query)]
            public string ClientVersion { get; private set; }
        }
    }
}