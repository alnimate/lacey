namespace Lacey.Medusa.Common.Resources.Resources.Business
{
    public abstract class LongIdResource : BusinessResource<long>
    {
        protected LongIdResource()
        {            
        }

        protected LongIdResource(long id)
            : base(id)
        {
        }
    }
}