using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWinApp.DataLayer
{
    class RepositoryStudents
    {
        public bool DoesStudentExist(long studentId)
        {
            bool ret = false;
            try
            {
                string sql = "select StudentId from Students where StudentId=@StudentId";
                List<SqlParameter> PList = new List<SqlParameter>();
                DBHelper.AddSqlParam(PList, "@StudentId",  SqlDbType.BigInt, studentId);
                object objId = DataAccess.GetSingleAnswer(sql, PList);
                if (objId != null)
                    ret = true;
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public float? GetGradeForACourse(long studentId, string courseNum)
        {
            float? grade = null;
            try
            {
                string sql = "select grade from CoursesCompleted where " +
                    "CourseNum=@CourseNum and StudentId=@StudentId ";
                List<SqlParameter> PList = new List<SqlParameter>();
                DBHelper.AddSqlParam(PList, "@StudentId",  SqlDbType.BigInt, studentId);
                DBHelper.AddSqlParam(PList, "@CourseNum", SqlDbType.VarChar, courseNum, 50);
                object objGrade = DataAccess.GetSingleAnswer(sql, PList);
                if (objGrade != null)
                    grade = float.Parse(objGrade.ToString());
            }
            catch (Exception)
            {
                throw;
            }
            return grade;
        }

        public bool HasStudentTakenPreRequisteCourses(long studentId, string courseNum, float minGrade)
        {
            bool ret = true;
            try
            {
                RepositoryCourses repCourses = new RepositoryCourses();
                List<string> PreReqList = repCourses.GetPreRequisiteCourses(courseNum);
                // determine the grade and see if each course is completed with minGrade or better
                foreach (string cnum in PreReqList)
                {
                    float? grade = GetGradeForACourse(studentId, cnum);
                    if ((grade == null) || (grade < minGrade))
                    {
                        ret = false;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public bool RegisterStudent(long studentId, string semester, string courseNum)
        {
            bool ret = false;
            try
            {
                string sql = "Insert into CourseEnrollments(StudentId,SemesterId,CourseNum) values" +
                    "(@StudentId,@SemesterId,@CourseNum)";
                List<SqlParameter> PList = new List<SqlParameter>();
                DBHelper.AddSqlParam(PList, "@StudentId",  SqlDbType.BigInt, studentId);
                DBHelper.AddSqlParam(PList, "@SemesterId",  SqlDbType.VarChar, semester, 20);
                DBHelper.AddSqlParam(PList, "@CourseNum", SqlDbType.VarChar, courseNum, 50);
                int rows = DataAccess.InsertUpdateDelete(sql, PList);
                if (rows > 0)
                    ret = true;
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }


    }
}
