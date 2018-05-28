using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace MicroFx.Dapper.MySql.TSql
{
    public class SqlFactory
    {
        public static string AddSql<TEntity>(TEntity t)
        {
            var type = t.GetType();
            var tableName = type.Name;
            var columnsName = type.GetProperties().Select(item => item.Name);
            var sql=  $@"INSERT INTO {tableName}({columnsName.ToString(",",item=>$"[{item}]")}) VALUES({columnsName.ToString(",",item=>$"@{item}")})";
            return sql;
        }

        public static string UpdateSql<TEntity>(TEntity t)
        {
            return string.Empty;
        }

        public static string DelSql<TEntity>(TEntity t)
        {
            var tableName = t.GetType();
            var sql = $"DELETE FROM {tableName} WHERE Id=@Id";
            return string.Empty;
        }
    }
}
