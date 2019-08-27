using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Http;
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

        public virtual ListRequest Insert(AuthRequest body)
        {
            return new ListRequest(this.service, body);
        }

        public sealed class ListRequest : LikesRockRequest<AuthInfo>
        {
            private readonly AuthRequest body;

            public ListRequest(
                IClientService service,
                AuthRequest body) : base(service)
            {
                this.body = body;

                this.InitParameters();
            }

            public override string MethodName => "insert";

            public override string RestPath => "ajax.php";

            public override string HttpMethod => HttpConsts.Post;

            protected override object GetBody()
            {
                return this.body;
            }

            protected override void InitParameters()
            {
                base.InitParameters();
            }
        }
    }
}