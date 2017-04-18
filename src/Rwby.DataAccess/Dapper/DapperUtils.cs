using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Rwby.DataAccess
{
    public static class DapperUtils
    {
        public static DynamicParameters GetDynamicParameter(IList<DbParameter> parameter)
        {
            var dynamicParam = new DynamicParameters();
            foreach (var para in parameter)
            {
                dynamicParam.Add(para.ParameterName, para.Value);
            }
            return dynamicParam;
        }
    }
}
