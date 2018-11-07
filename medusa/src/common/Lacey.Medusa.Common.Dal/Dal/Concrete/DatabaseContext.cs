using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Lacey.Medusa.Common.Dal.Utils;
using Microsoft.EntityFrameworkCore;

namespace Lacey.Medusa.Common.Dal.Dal.Concrete
{
    public abstract class DatabaseContext : DbContext, IDbContext
    {
        protected DatabaseContext(string connectionString)
            : base(new DbContextOptionsBuilder()
                    .UseSqlServer(connectionString,
                        p => p.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)).Options)
        {
        }

        protected DatabaseContext(DbContextOptions options)
            : base(options)
        {            
        }

        public virtual int Commit()
        {
            return this.SaveChanges();
        }

        public string GetTableName<T>()
        {
            return this.GetDatabaseTableName<T>();
        }

        public void ExecuteCommand(string command, params object[] parameters)
        {
            this.Database.ExecuteSqlCommand(command, parameters);
        }

        public virtual async Task<int> CommitAsync()
        {
            return await this.SaveChangesAsync();
        }

        public async Task BulkAddAsync<T>(IEnumerable<T> entities) where T : class
        {
            await this.BulkInsertAsync(entities.ToList());
        }
    }
}