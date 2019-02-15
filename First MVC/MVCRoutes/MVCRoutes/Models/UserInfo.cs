using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCRoutes.Models
{
    public class UserInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address UserAddress { get; set; }
    }
}