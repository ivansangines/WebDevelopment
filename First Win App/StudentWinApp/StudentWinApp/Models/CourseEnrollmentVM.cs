using StudentWinApp.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StudentWinApp.Models
{
    class CourseEnrollmentVM : MyEntityBase//IEntity
    {
        public long StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public string Email { get; set; }
        public int Credits { get; set; }

        //public void PopulateFields(DataRow dr)
        //{
        //    this.FirstName = (string) dr["FirstName"];
        //    this.LastName = (string)dr["LastName"];
        //    this.Major = (string)dr["Major"];
        //    this.Email = (string)dr["Email"];
        //    this.StudentId = (long)dr["StudentId"];
        //    this.Credits = (int)dr["Credits"];
        //}
    }
}
