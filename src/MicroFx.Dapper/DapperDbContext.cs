using MicroFx.Data;
using MicroFx.Data.Repository;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Dapper;

namespace MicroFx.Dapper
{
    public abstract class DapperDbContext : MicroFxDbContext, IDisposable
    {
        public DapperDbContext(ContextOptions options) : base(options)
        {
        }

        public override void Execute(ChangeDescript changeDescript)
        {
            throw new NotImplementedException();
        }

        protected override IDbConnection GetDbConnection(string connStr)
        {
            throw new NotImplementedException();
        }
    }
}
