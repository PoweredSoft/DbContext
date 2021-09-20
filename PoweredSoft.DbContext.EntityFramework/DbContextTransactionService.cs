using PoweredSoft.DbContext.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.DbContext.EntityFramework
{
    public class DbContextTransactionService : IDbContextTransactionService
    {
        private readonly System.Data.Entity.DbContextTransaction dbContextTransaction;

        public DbContextTransactionService(System.Data.Entity.DbContextTransaction dbContextTransaction)
        {
            this.dbContextTransaction = dbContextTransaction;
        }

        public void Commit() => dbContextTransaction.Commit();

        public void Dispose() => dbContextTransaction.Dispose();

        public void Rollback() => dbContextTransaction.Rollback();
    }
}
