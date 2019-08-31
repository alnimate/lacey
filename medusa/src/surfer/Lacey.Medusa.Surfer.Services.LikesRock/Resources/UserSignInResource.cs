using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.SignIn;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Resources
{
    public sealed class UserSignInResource : LikesRockResource
    {
        public UserSignInResource(IClientService service) : base(service)
        {
        }

        public SignInBvbRequest SignInBvb(string userLang, string clientVersion)
        {
            return new SignInBvbRequest(this.Service, userLang, clientVersion);
        }

        public SignInSessionIdRequest SignInSessionId(string userLang, string clientVersion, string security)
        {
            return new SignInSessionIdRequest(this.Service, userLang, clientVersion, security);
        }

        public sealed class SignInBvbRequest : LikesRockRequest<SignInBvbResponseModel>
        {
            public SignInBvbRequest(
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

            public override string RestPath => "user_signin.php";

            public override string HttpMethod => HttpConsts.Get;

            [RequestParameter("user_lang", RequestParameterType.Query)]
            public string UserLang { get; private set; }

            [RequestParameter("client_version", RequestParameterType.Query)]
            public string ClientVersion { get; private set; }
        }

        public sealed class SignInSessionIdRequest : LikesRockRequest<string>
        {
            public SignInSessionIdRequest(
                IClientService service, 
                string userLang, 
                string clientVersion, 
                string security) : base(service)
            {
                UserLang = userLang;
                ClientVersion = clientVersion;
                Security = security;

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


                this.RequestParameters.Add("security", new Parameter
                {
                    Name = "security",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });
            }

            public override string RestPath => "user_signin.php";

            public override string HttpMethod => HttpConsts.Get;

            [RequestParameter("user_lang", RequestParameterType.Query)]
            public string UserLang { get; private set; }

            [RequestParameter("client_version", RequestParameterType.Query)]
            public string ClientVersion { get; private set; }

            [RequestParameter("security", RequestParameterType.Query)]
            public string Security { get; private set; }
        }
    }
}