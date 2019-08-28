using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Login;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Resources
{
    public sealed class AjaxResource : LikesRockResource
    {
        public AjaxResource(IClientService service) : base(service)
        {
        }

        public LoginRequest Login(LoginRequestModel body)
        {
            return new LoginRequest(this.Service, body);
        }

        public sealed class LoginRequest : LikesRockRequest<LoginResponseModel>
        {
            private readonly LoginRequestModel body;

            public LoginRequest(
                IClientService service,
                LoginRequestModel body) : base(service)
            {
                this.body = body;
            }

            public override string RestPath => "ajax.php";

            public override string HttpMethod => HttpConsts.Post;

            protected override object GetBody()
            {
                return this.body;
            }
        }
    }
}