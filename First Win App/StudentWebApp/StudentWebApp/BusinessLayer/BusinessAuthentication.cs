using StudentWebApp.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebApp.BusinessLayer
{
    class BusinessAuthentication : IBusinessAuthentication
    {
        IAuthentication _iauth = null;

        public BusinessAuthentication()
        {
            _iauth = new Authentication();
        }

        public bool VerifyLogin(string username, string password)
        {
            return _iauth.VerifyLogin(username, password);
        }
    }
}