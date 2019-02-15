using StudentWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.DataLayer
{
    interface IRepositoryCourses
    {
        int GetEnrollmentCount(string semester, string courseNum);

        List<string> GetSemesters();

        List<CourseOfferedVM> GetCoursesOffered(string semester);

        List<CourseEnrollmentVM> GetCourseEnrollment(string semester, string courseNum);

        List<string> GetCoursesOfferedForASemester(string semester);

        List<string> GetPreRequisiteCourses(string courseNum);

        bool IsThereRoomInTheCourse(string semester, string courseNum);


    }
}
