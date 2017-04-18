using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Rwby.DataAccess
{
    public static class SqlBuilderUtils
    {
      
        public static string GetCountSql(string selectAllSql)
        {
            var sql = string.Format
            (
                @"  SELECT  COUNT(*)
                    FROM    ({0}
                    ) as p
                        "
            , selectAllSql);

            return sql;
        }

        public static string GetCondtionSql(string selectAllSql, string condtion)
        {
            var sql = string.Format("SELECT * FROM ( {0} ) AS t  WHERE 1=1 {1} ", selectAllSql, condtion);
            return sql;
        }
    }
}