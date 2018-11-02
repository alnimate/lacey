namespace Lacey.Medusa.Common.Resources.Resources.Business
{
    public abstract class IntIdResource : BusinessResource<int>
    {
        protected IntIdResource()
        {            
        }

        protected IntIdResource(int id)
            : base(id)
        {
        }
    }
}