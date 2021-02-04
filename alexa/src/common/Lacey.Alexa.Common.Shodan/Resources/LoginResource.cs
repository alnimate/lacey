using Lacey.Alexa.Common.Shodan.Common;
using Lacey.Alexa.Common.Shodan.Models.Login;
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Http;

namespace Lacey.Alexa.Common.Shodan.Resources
{
    public sealed class LoginResource : BaseResource
    {
        public LoginResource(IClientService service) : base(service)
        {
        }

        public LoginGetRequest LoginGet()
        {
            return new(Service);
        }

        public LoginRequest Login(string username,
            string password,
            string grantType,
            string continu,
            string csrfToken)
        {
            return new(Service, username, password, grantType, continu, csrfToken);
        }

        public sealed class LoginGetRequest : BaseRequest<string>
        {
            public LoginGetRequest(IClientService service) : base(service)
            {
            }

            public override string RestPath => "login";

            public override string HttpMethod => HttpConsts.Get;
        }

        public sealed class LoginRequest : BaseRequest<string>
        {
            private readonly LoginRequestModel _body;

            public LoginRequest(
                IClientService service,
                string username,
                string password,
                string grantType,
                string continu,
                string csrfToken) : base(service)
            {
                _body = new LoginRequestModel
                {
                    Username = username,
                    Password = password,
                    GrantType = grantType,
                    Continue = continu,
                    CsrfToken = csrfToken
                };
            }

            public override string RestPath => "login";

            public override string HttpMethod => HttpConsts.Post;

            protected override object GetBody()
            {
                return _body;
            }
        }
    }
}