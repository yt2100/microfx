using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFx.Data
{
    public class DefaultDBContext : IDBContext
    {
        public IRepository GetRepository<TEntity>(bool enableTrans)
        {
            throw new NotImplementedException();
        }

        public void TryCommit(Action success = null, Action<Exception> error = null)
        {
            throw new NotImplementedException();
        }
    }
}
