using System;

namespace Lacey.Medusa.Common.Resources.Resources.Business
{
    public abstract class GuidIdResource : BusinessResource<Guid>
    {
        protected GuidIdResource()
        {            
        }

        protected GuidIdResource(Guid id)
            : base(id)
        {
        }
    }
}
