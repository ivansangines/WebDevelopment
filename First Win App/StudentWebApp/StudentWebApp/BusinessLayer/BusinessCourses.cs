using StudentWebApp.DataLayer;
using StudentWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.BusinessLayer
{
    class BusinessCourses : IBusinessCourses
    {
        //RepositoryCourses _rep = new RepositoryCourses();
        IRepositoryCourses _irc = null;        
        

        public BusinessCourses()
        {
            _irc = new RepositoryCourses();
           
        }

        public BusinessCourses(IRepositoryCourses irc)
        {
            _irc = irc;
        }
        // the UI layer always communicates with the business layer
        // even if no code is needed, the business layer forwards the request to repository in data layer
        public List<string> GetSemesters()
        {
            return _irc.GetSemesters();
        }

        public List<CourseOfferedVM> GetCoursesOffered(string semester)
        {
            return _irc.GetCoursesOffered(semester);
        }

        public List<CourseEnrollmentVM> GetCourseEnrollment(string semester, string courseNum)
        {
            return _irc.GetCourseEnrollment(semester, courseNum);
        }

        public List<string> GetCoursesOfferedForASemester(string semester)
        {
            return _irc.GetCoursesOfferedForASemester(semester);
        }

        
    }
}
