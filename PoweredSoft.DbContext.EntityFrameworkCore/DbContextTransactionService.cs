using Microsoft.EntityFrameworkCore.Storage;
using PoweredSoft.DbContext.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.DbContext.EntityFrameworkCore
{
    public class DbContextTransactionService : IDbContextTransactionService
    {
        private readonly IDbContextTransaction dbContextTransaction;

        public DbContextTransactionService(IDbContextTransaction dbContextTransaction)
        {
            this.dbContextTransaction = dbContextTransaction;
        }

        public void Commit() => dbContextTransaction.Commit();

        public void Dispose() => dbContextTransaction.Dispose();

        public void Rollback() => dbContextTransaction.Rollback();
    }
}
