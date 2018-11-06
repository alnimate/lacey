using System;
using System.Threading.Tasks;

namespace Lacey.Medusa.Common.Dal.Dal
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TSet> GetRepository<TSet>() where TSet : class;

        int Save();

        Task<int> SaveAsync();
    }
}