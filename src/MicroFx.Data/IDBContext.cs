using MicroFx.Data.Repository;
using System;
using System.Data;

namespace MicroFx.Data
{
    public interface IDBContext
    {
        ContextOptions Options { get; }

        IDbConnection Connection { get; }

        IDbTransaction Transaction { get; }

        TRepository GetRepository<TRepository>() where TRepository : IRepository<Entity>;

        void SaveChange();
        void Execute(ChangeDescript changeDescript);
    }
}
