using System.Collections.Generic;
using Lacey.Medusa.Common.Api.Base.Services;

namespace Lacey.Medusa.Common.Core.Api
{
    public abstract class ApiProvider : BaseClientService
    {
        public override IList<string> Features => new string[0];

        protected ApiProvider(Initializer initializer) : base(initializer)
        {
        }
    }
}