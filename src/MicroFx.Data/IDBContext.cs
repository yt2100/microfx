using System;

namespace MicroFx.Data
{
    public interface IDBContext
    {
        IRepository GetRepository<TEntity>(bool enableTrans);

        void TryCommit(Action success = null, Action<Exception> error = null);
    }
}
