using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.DataLayer
{
    interface IDataAccess
    {
        object GetSingleAnswer(string sql, List<SqlParameter> PList, SqlConnection connc = null, SqlTransaction sqtr = null, bool IsStoredProc = false);

        DataTable GetManyRowsCols(string sql, List<SqlParameter> PList, SqlConnection connc = null, SqlTransaction sqtr = null, bool IsStoredProc = false);

        int InsertUpdateDelete(string sql, List<SqlParameter> PList, SqlConnection connc = null, SqlTransaction sqtr = null, bool IsStoredProc = false);
    }
}
