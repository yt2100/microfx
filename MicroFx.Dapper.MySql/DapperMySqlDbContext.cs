using System;
using System.Data;
using MicroFx.Dapper.MySql.TSql;
using MicroFx.Data;
using MicroFx.Data.Repository;
using MySql.Data.MySqlClient;

namespace MicroFx.Dapper.MySql
{
    public class DapperMySqlDbContext : DapperDbContext
    {
        public DapperMySqlDbContext(ContextOptions options) : base(options)
        {
        }

        public override void Execute(ChangeDescript changeDescript)
        {
            var change = (ChangeDescript<Entity>)changeDescript;
            switch(change.ChangeType)
            {
                case ChangeType.Add:
                    SqlFactory.AddSql(change.Entity);
                    break;
                case ChangeType.Del:
                    break;
                case ChangeType.Update:
                    break;
                case ChangeType.Query:
                    break;
            }
        }

        protected override IDbConnection GetDbConnection(string connStr)
        {
            return new MySqlConnection(connStr);
        }
    }
}
