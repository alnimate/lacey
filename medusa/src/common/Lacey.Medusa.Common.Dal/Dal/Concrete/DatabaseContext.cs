﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Dal.Utils;
using Microsoft.EntityFrameworkCore;

namespace Lacey.Medusa.Common.Dal.Dal.Concrete
{
    public abstract class DatabaseContext : DbContext, IDbContext
    {
        protected DatabaseContext(string connectionString)
            : base(new DbContextOptionsBuilder()
                    .UseSqlServer(connectionString, opt => opt.UseRowNumberForPaging()).Options)
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

        public void BulkAdd<T>(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<int> CommitAsync()
        {
            return await this.SaveChangesAsync();
        }
    }
}