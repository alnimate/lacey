using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Const;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetSurfUrl;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Login;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.RecordAction;

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

        public RecordActionRequest RecordAction(
            string userAccessToken,
            string taskId,
            string socialId,
            string taskHash,
            string clicked)
        {
            return new RecordActionRequest(this.Service, AjaxMode.RecordAction, userAccessToken,
                taskId, socialId, taskHash, clicked);
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

        public sealed class RecordActionRequest : LikesRockRequest<RecordActionResponseModel>
        {
            public RecordActionRequest(
                IClientService service, 
                string mode, 
                string userAccessToken, 
                string taskId, 
                string socialId, 
                string taskHash, 
                string clicked) : base(service)
            {
                Mode = mode;
                UserAccessToken = userAccessToken;
                TaskId = taskId;
                SocialId = socialId;
                TaskHash = taskHash;
                Clicked = clicked;

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

                this.RequestParameters.Add("task_id", new Parameter
                {
                    Name = "task_id",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("social_id", new Parameter
                {
                    Name = "social_id",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("task_hash", new Parameter
                {
                    Name = "task_hash",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("clicked", new Parameter
                {
                    Name = "clicked",
                    IsRequired = false,
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

            [RequestParameter("task_id", RequestParameterType.Query)]
            public string TaskId { get; private set; }

            [RequestParameter("social_id", RequestParameterType.Query)]
            public string SocialId { get; private set; }

            [RequestParameter("task_hash", RequestParameterType.Query)]
            public string TaskHash { get; private set; }

            [RequestParameter("clicked", RequestParameterType.Query)]
            public string Clicked { get; private set; }
        }
    }
}