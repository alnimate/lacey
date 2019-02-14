using Lacey.Medusa.Common.Dal.Dal.Concrete;

namespace Lacey.Medusa.Youtube.Dal.Dal.Concrete
{
    public sealed class YoutubeUnitOfWorkFactory : UnitOfWorkFactory, IYoutubeUnitOfWorkFactory
    {
        public YoutubeUnitOfWorkFactory(IYoutubeSessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}