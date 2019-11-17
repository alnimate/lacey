using System.Collections.Generic;
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Surfer.Services.LikesRock.Resources;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Providers.Concrete
{
    public sealed class LrProvider : BaseClientService
    {
        public LrProvider(Initializer initializer) : base(initializer)
        {
            this.UserSignIn= new UserSignInResource(this);
            this.Ajax = new AjaxResource(this);
            this.GetTasks = new GetTasksResource(this);
            this.GetStats = new GetStatsResource(this);
        }

        public override string Name => "LikesRock";

        public override string BaseUri => "https://likesrock.com/client-v2/";

        public override string BasePath => "client-v2/";

        public override IList<string> Features => new string[0];

        public UserSignInResource UserSignIn { get; }

        public AjaxResource Ajax { get; }

        public GetTasksResource GetTasks { get; }

        public GetStatsResource GetStats { get; }
    }
}