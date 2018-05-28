using MicroFx.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFx.Data
{
    public static class ContextOptionsExtensiongs
    {
        public static ContextOptions UseMySql(this ContextOptions options, string connStr)
        {
            options.ConnectionString = connStr;
            return options;
        }
    }
}
