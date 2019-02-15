using StudentWinApp.DataLayer;
using StudentWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWinApp.BusinessLayer
{
    class BusinessCourses
    {
        RepositoryCourses _rep = new RepositoryCourses();
        // the UI layer always communicates with the business layer
        // even if no code is needed, the business layer forwards the request to repository in data layer
        public List<string> GetSemesters()
        {
            return _rep.GetSemesters();
        }

        public List<CourseOfferedVM> GetCoursesOffered(string semester)
        {
            return _rep.GetCoursesOffered(semester);
        }

        public List<CourseEnrollmentVM> GetCourseEnrollment(string semester, string courseNum)
        {
            return _rep.GetCourseEnrollment(semester, courseNum);
        }

        public List<string> GetCoursesOfferedForASemester(string semester)
        {
            return _rep.GetCoursesOfferedForASemester(semester);
        }
    }
}
