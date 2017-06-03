using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Rwby.DataAccess
{
    public interface IPagingSql
    {

        IList<DbParameter> GetRowRangeParameter(
           int pageIndex
            , int pageSize
            , string rowBeginName
            , string rowEndName
           );

        string GetPagingSql(
            string selectAllSql
            , string orderFieldName
            , string rowName
            , string rowBeginName
            , string rowEndName
     );



    }
}
