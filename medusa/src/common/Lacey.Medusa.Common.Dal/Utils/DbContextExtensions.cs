using Microsoft.EntityFrameworkCore;

namespace Lacey.Medusa.Common.Dal.Utils
{
    public static class DbContextExtensions
    {
        public static string GetDatabaseTableName<TEntity>(this DbContext context)
        {
            return context.Model.FindEntityType(typeof(TEntity).Name).GetTableName();
        }
    }
}