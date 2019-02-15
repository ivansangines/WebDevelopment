using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentWebApp.DataLayer
{
    class Authentication:IAuthentication
    {
        IDataAccess _idac = null;

        public Authentication()
        {
            _idac = new DataAccess();
        }

        public Authentication(IDataAccess idac)
        {
            _idac = idac;
        }

        public bool VerifyLogin(string username, string password)
        {
            bool ret = false;
            try
            {
                string sql = "select Username from Users where Username= @username  and Password=@password";
                List<SqlParameter> AList = new List<SqlParameter>();
                DBHelper.AddSqlParam(AList, "@username", SqlDbType.VarChar, username, 30);
                DBHelper.AddSqlParam(AList, "@password", SqlDbType.VarChar, password, 30);
                object obj = _idac.GetSingleAnswer(sql, AList);
                if (obj != null)
                    ret = true;
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }
    }
}