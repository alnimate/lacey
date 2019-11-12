using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetTasks;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Resources
{
    public sealed class GetTasksResource : LikesRockResource
    {
        public GetTasksResource(IClientService service) : base(service)
        {
        }

        public GetTasksRequest GetTasks(string userAccessToken, int targetId, string v)
        {
            return new GetTasksRequest(this.Service, userAccessToken, targetId, v);
        }

        public sealed class GetTasksRequest : LikesRockRequest<GetTasksResponseModel>
        {
            public GetTasksRequest(
                IClientService service, 
                string userAccessToken,
                int targetId,
                string v) : base(service)
            {
                UserAccessToken = userAccessToken;
                TargetId = targetId;
                V = v;

                this.RequestParameters.Add("user_access_token", new Parameter
                {
                    Name = "user_access_token",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("target_id", new Parameter
                {
                    Name = "target_id",
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

            public override string RestPath => "get_tasks.php";

            public override string HttpMethod => HttpConsts.Get;

            [RequestParameter("user_access_token", RequestParameterType.Query)]
            public string UserAccessToken { get; private set; }

            [RequestParameter("target_id", RequestParameterType.Query)]
            public int TargetId { get; private set; }

            [RequestParameter("v", RequestParameterType.Query)]
            public string V { get; private set; }
        }
    }
}