using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Rwby.DataAccess
{
    public class MSSqlPagingSql : IPagingSql
    {
        public IList<DbParameter> GetRowRangeParameter(
               int pageIndex, int pageSize
               , string rowBeginName = "@RowBegin"
               , string rowEndName = "@RowEnd"
               )
        {
            if (pageSize == 0)
            {
                pageSize = 10;
            }
            var rowBegin = (pageIndex * pageSize) + 1;
            var rowEnd = (pageIndex + 1) * pageSize;

            var parmList = new List<DbParameter>();
            parmList.Add(new SqlParameter(rowBeginName, rowBegin));
            parmList.Add(new SqlParameter(rowEndName, rowEnd));
            return parmList;
        }




        public string GetPagingSql(
            string selectAllSql
            , string orderFieldName = "CreateTime"
            , string rowName = "RowNum"
            , string rowBeginName = "@RowBegin"
            , string rowEndName = "@RowEnd"
            )
        {
            var sql = string.Format
                (
                  @"  SELECT * FROM ( 
                        SELECT
                        ROW_NUMBER() OVER ( ORDER BY {1} DESC ) AS {2} , * 
                        FROM   ({0}
                        ) AS p
                    ) AS t
                        WHERE
                    {2} BETWEEN {3} AND {4}"
                , selectAllSql, orderFieldName, rowName, rowBeginName, rowEndName);

            return sql;
        }
    }
}
