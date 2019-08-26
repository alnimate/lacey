using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Resources
{
    public class AuthResource
    {
        private readonly IClientService service;

        public AuthResource(IClientService service)
        {
            this.service = service;
        }

        public virtual ListRequest List(
            string userName,
            string userPass,
            string userLang,
            string clientVersion,
            string security)
        {
            return new ListRequest(this.service, userName, userPass, userLang, clientVersion, security);
        }

        public sealed class ListRequest : LikesRockRequest<AuthInfo>
        {
            public ListRequest(
                IClientService service,
                string userName,
                string userPass,
                string userLang,
                string clientVersion,
                string security) : base(service)
            {
                this.UserLang = userLang;
                this.ClientVersion = clientVersion;
                this.Security = security;
                this.InitParameters();
            }

            [RequestParameter("user_lang", RequestParameterType.Query)]
            public string UserLang { get; private set; }

            [RequestParameter("client_version", RequestParameterType.Query)]
            public string ClientVersion { get; private set; }

            [RequestParameter("security", RequestParameterType.Query)]
            public string Security { get; private set; }

            public override string MethodName => "list";

            public override string RestPath => "user_signin.php";

            public override string HttpMethod => "POST";

            protected override void InitParameters()
            {
                base.InitParameters();

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
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });
            }
        }
    }
}