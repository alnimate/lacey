using Lacey.Medusa.Common.Dal.Dal.Concrete;

namespace Lacey.Medusa.Instagram.Dal.Dal.Concrete
{
    public sealed class InstagramUnitOfWorkFactory : UnitOfWorkFactory, IInstagramUnitOfWorkFactory
    {
        public InstagramUnitOfWorkFactory(IInstagramSessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}