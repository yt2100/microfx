using MicroFx.Data;
using MicroFx.Data.Repository;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace MicroFx.Data
{
    public abstract class MicroFxDbContext : IDBContext,IDisposable
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public readonly IList<IRepository> repositories = new List<IRepository>();

        public IDbConnection Connection { get;private set; }

        public IDbTransaction Transaction { get; private set; }

        public ContextOptions Options { get; private set; }

        public MicroFxDbContext(ContextOptions options)
        {
            Options = options;
        }

        protected abstract IDbConnection GetDbConnection(string connStr);

        public void SaveChange()
        {
            Connection =Connection ?? GetDbConnection(Options.ConnectionString);
            if (Connection == null)
            {
                throw new Exception("初始IDbConnection失败");
            }
            try
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
                Transaction = Transaction ?? Connection.BeginTransaction();
                foreach (var repository in repositories)
                {
                    repository.AcceptChange();
                }

                Transaction.Commit();
            }
            catch (Exception ex)
            {
                Transaction?.Rollback();
                throw ex;
            }
            finally
            {
                Transaction?.Dispose();
                Transaction = null;
                Connection.Close();                
            }
        }

        public TRepository GetRepository<TRepository>() where TRepository:IRepository<Entity>
        {
            var serviceProvider=ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext.RequestServices;
            var repository=serviceProvider.GetService<TRepository>();
            repositories.Add(repository);
            return repository;
        }

        public abstract void Execute(ChangeDescript changeDescript);

        public void Dispose()
        {
            Transaction?.Dispose();
            Transaction = null;
            Connection?.Close();
            Connection?.Dispose();
            Connection = null;
        }
    }
}
