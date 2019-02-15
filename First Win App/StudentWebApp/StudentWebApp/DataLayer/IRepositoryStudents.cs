using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.DataLayer
{
    interface IRepositoryStudents
    {
        bool DoesStudentExist(long studentId);

        float? GetGradeForACourse(long studentId, string courseNum);

        bool HasStudentTakenPreRequisteCourses(long studentId, string courseNum, float minGrade);

        bool RegisterStudent(long studentId, string semester, string courseNum);
    }
}
