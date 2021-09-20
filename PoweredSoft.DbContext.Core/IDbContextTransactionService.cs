using System;

namespace PoweredSoft.DbContext.Core
{
    public interface IDbContextTransactionService : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
