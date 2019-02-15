using StudentWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.BusinessLayer
{
    interface IBusinessCourses
    {
        List<string> GetSemesters();

        List<CourseOfferedVM> GetCoursesOffered(string semester);

        List<CourseEnrollmentVM> GetCourseEnrollment(string semester, string courseNum);

        List<string> GetCoursesOfferedForASemester(string semester);

    }
}
