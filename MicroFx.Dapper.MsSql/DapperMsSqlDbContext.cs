using System;
using System.Data;
using System.Data.SqlClient;
using MicroFx.Data;
using MicroFx.Data.Repository;

namespace MicroFx.Dapper.MsSql
{
    public class DapperMsSqlDbContext : DapperDbContext
    {
        public DapperMsSqlDbContext(ContextOptions options) : base(options)
        {
        }

        public override void Execute(ChangeDescript changeDescript)
        {
            throw new NotImplementedException();
        }

        protected override IDbConnection GetDbConnection(string connStr)
        {
            return new SqlConnection(connStr);
        }
    }
}
