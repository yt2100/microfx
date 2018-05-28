using MicroFx.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFx.Data
{
    public static class ContextOptionsExtensiongs
    {
        public static ContextOptions UseMsSql(this ContextOptions options, string connStr)
        {
            options.ConnectionString = connStr;
            return options;
        }
    }
}
