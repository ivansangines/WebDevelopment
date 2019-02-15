using StudentWinApp.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWinApp.BusinessLayer
{
    class BusinessStudents
    {
        RepositoryCourses repCourses = new RepositoryCourses();
        RepositoryStudents repStudents = new RepositoryStudents();
        public bool RegisterStudent(long studentId, string semester, string courseNum)
        {
            bool ret = false;
            try
            {
                if (repStudents.DoesStudentExist(studentId))
                {
                    if (repStudents.HasStudentTakenPreRequisteCourses(studentId, courseNum, 2.0f))
                    {
                        if (repCourses.IsThereRoomInTheCourse(semester, courseNum))
                            ret = repStudents.RegisterStudent(studentId, semester, courseNum);
                        else
                            throw new Exception("Course capacity exceeded..");
                    }
                    else
                        throw new Exception("Missing prerequisites for " + courseNum);
                }
                else
                    throw new Exception("Invalid student Id..");
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

    }
}
