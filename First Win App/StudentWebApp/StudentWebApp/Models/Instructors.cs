using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebApp.Models
{
    class Instructors : MyEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Department { get; set; }
        
    }
}