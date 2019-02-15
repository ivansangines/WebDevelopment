using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWinApp.DataLayer
{
    class DBHelper
    {
        public static void AddSqlParam(List<SqlParameter> PList, string paramName,
            SqlDbType paramType, object paramValue, int size=0)
        {
            SqlParameter p = null;
            if (size == 0)
                p = new SqlParameter(paramName, paramType);
            else
                p = new SqlParameter(paramName, paramType, size);
            p.Value = paramValue;
            PList.Add(p);
        }
    }
}
