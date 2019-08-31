using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Const;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetSurfUrl;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Login;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Resources
{
    public sealed class AjaxResource : LikesRockResource
    {
        public AjaxResource(IClientService service) : base(service)
        {
        }

        public LoginRequest Login(string userName, string password)
        {
            return new LoginRequest(this.Service, userName, password);
        }

        public GetSurfUrlRequest GetSurfUrl(string userAccessToken)
        {
            return new GetSurfUrlRequest(this.Service, AjaxMode.GetSurfUrl, userAccessToken);
        }

        public sealed class LoginRequest : LikesRockRequest<LoginResponseModel>
        {
            private readonly LoginRequestModel body;

            public LoginRequest(
                IClientService service,
                string userName,
                string password) : base(service)
            {
                this.body = new LoginRequestModel
                {
                    Mode = AjaxMode.Login,
                    Username = userName,
                    Password = password
                };
            }

            public override string RestPath => "ajax.php";

            public override string HttpMethod => HttpConsts.Post;

            protected override object GetBody()
            {
                return this.body;
            }
        }

        public sealed class GetSurfUrlRequest : LikesRockRequest<GetSurfUrlResponseModel>
        {
            public GetSurfUrlRequest(
                IClientService service, string mode, string userAccessToken) : base(service)
            {
                Mode = mode;
                UserAccessToken = userAccessToken;

                this.RequestParameters.Add("mode", new Parameter
                {
                    Name = "mode",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("user_access_token", new Parameter
                {
                    Name = "user_access_token",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });
            }

            public override string RestPath => "ajax.php";

            public override string HttpMethod => HttpConsts.Get;

            [RequestParameter("mode", RequestParameterType.Query)]
            public string Mode { get; private set; }

            [RequestParameter("user_access_token", RequestParameterType.Query)]
            public string UserAccessToken { get; private set; }
        }
    }
}