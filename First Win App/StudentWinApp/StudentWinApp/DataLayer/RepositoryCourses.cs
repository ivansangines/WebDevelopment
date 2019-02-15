using StudentWinApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWinApp.DataLayer
{
    class RepositoryCourses  // purpose of repository is to serve data
    {     // if data is being obtained from a Database Server, then the repository
          // assembles SQL and its parameters for a given task

       public int GetEnrollmentCount(string semester, string courseNum)
        {
            int enrollCount = 0;
            try
            {
                string sql = "select count(*) from CourseEnrollments where SemesterId=@SemesterId and " +
                    "CourseNum=@CourseNum";
                List<SqlParameter> PList = new List<SqlParameter>();
                DBHelper.AddSqlParam(PList, "@SemesterId", SqlDbType.VarChar, semester, 20);
                DBHelper.AddSqlParam(PList, "@CourseNum", SqlDbType.VarChar, courseNum, 50);
                object objCount = DataAccess.GetSingleAnswer(sql, PList);
                if (objCount != null)
                    enrollCount = int.Parse(objCount.ToString());
            }
            catch(Exception)
            {
                throw;
            }
            return enrollCount;
        }

        public List<string> GetSemesters()
        {
            List<string> SList = new List<string>();
            try
            {
                string sql = "select SemesterId from Semesters";
                DataTable dt = DataAccess.GetManyRowsCols(sql, null);
                // convert datatable to List<string>
                foreach (DataRow dr in dt.Rows)
                    SList.Add(dr["SemesterId"].ToString());
            }
            catch (Exception)
            {
                throw;
            }
            return SList;
        }

        public List<CourseOfferedVM> GetCoursesOffered(string semester)
        {
            List<CourseOfferedVM> CList = new List<CourseOfferedVM>();
            try
            {
                string sql = "select co.CourseNum, c.CourseName, c.Credits, co.Capacity," +
                    "i.LastName as Instructor from CoursesOffered co " +
                    "inner join Courses c on co.CourseNum=c.CourseNum " +
                    "inner join Instructors i on co.InstructorId=i.InstructorId where " +
                    "co.SemesterId=@SemesterId";
                List<SqlParameter> PList = new List<SqlParameter>();
                DBHelper.AddSqlParam(PList, "@SemesterId", SqlDbType.VarChar, semester, 20);
                DataTable dt = DataAccess.GetManyRowsCols(sql, PList);
                // convert data table to List<CourseOfferedVM>
                foreach (DataRow dr in dt.Rows)
                {
                    CourseOfferedVM covm = new CourseOfferedVM();
                    covm.CourseNum = dr["CourseNum"].ToString();
                    covm.CourseName = dr["CourseName"].ToString();
                    covm.Credits = (int)dr["Credits"];
                    covm.Capacity = (int)dr["Capacity"];
                    covm.Instructor = dr["Instructor"].ToString();
                    covm.Enrolled = GetEnrollmentCount(semester, covm.CourseNum);
                    CList.Add(covm);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return CList;
        }

        public List<CourseEnrollmentVM> GetCourseEnrollment(string semester, string courseNum)
        {
            List<CourseEnrollmentVM> CList = new List<CourseEnrollmentVM>();
            try
            {
                string sql = "select s.StudentId, s.FirstName, s.LastName, s.Email, c.Credits," +
                    "d.DepartmentName as Major from Students s " +
                    "inner join CourseEnrollments ce on s.StudentId=ce.StudentId " +
                    "inner join Courses c on ce.CourseNum=c.CourseNum " +
                    "inner join StudentDepartments sd on s.StudentId=sd.StudentId " +
                    "inner join Departments d on sd.DepartmentId=d.DepartmentId " +
                    "where ce.SemesterId=@SemesterId and ce.CourseNum=@CourseNum";
                List<SqlParameter> PList = new List<SqlParameter>();
                DBHelper.AddSqlParam(PList, "@SemesterId", SqlDbType.VarChar, semester, 20);
                DBHelper.AddSqlParam(PList, "@CourseNum", SqlDbType.VarChar, courseNum, 50);
                DataTable dt = DataAccess.GetManyRowsCols(sql, PList);
                // convert datatable to List<CurseEnrollmentVM>
                CList = DBList.GetList<CourseEnrollmentVM>(dt);

                //foreach (DataRow dr in dt.Rows)
                //{
                //    CourseEnrollmentVM cevm = new CourseEnrollmentVM();
                //    cevm.StudentId = (long)dr["StudentId"];
                //    cevm.FirstName = (string)dr["FirstName"];
                //    cevm.LastName = (string)dr["LastName"];
                //    cevm.Email = (string)dr["Email"];
                //    cevm.Major = (string)dr["Major"];
                //    cevm.Credits = (int)dr["Credits"];
                //    CList.Add(cevm);
                //}
            }
            catch(Exception)
            {
                throw;
            }
            return CList;

        }

        public List<string> GetCoursesOfferedForASemester(string semester)
        {
            List<string> CList = new List<string>();
            try
            {
                string sql = "select CourseNum from CoursesOffered where SemesterId=@SemesterId";
                List<SqlParameter> PList = new List<SqlParameter>();
                DBHelper.AddSqlParam(PList, "@SemesterId", SqlDbType.VarChar, semester, 20);
                DataTable dt = DataAccess.GetManyRowsCols(sql, PList);
                // convert dt to List<string>
                //foreach (DataRow dr in dt.Rows)
                //    CList.Add(dr["CourseNum"].ToString());
                CList = DBList.GetListValueType<string>(dt,"CourseNum");
            }
            catch(Exception)
            {
                throw;
            }
            return CList;
        }

        public List<string> GetPreRequisiteCourses(string courseNum)
        {
            List<string> CList = new List<string>();
            try
            {
                string sql = "select PreReqCourseNum from CoursePreRequisites where CourseNum=@CourseNum";
                List<SqlParameter> PList = new List<SqlParameter>();
                DBHelper.AddSqlParam(PList, "@CourseNum", SqlDbType.VarChar, courseNum, 50);
                DataTable dt = DataLayer.DataAccess.GetManyRowsCols(sql, PList);
                CList = DBList.GetListValueType<string>(dt, "PreReqCourseNum");
            }
            catch (Exception)
            {
                throw;
            }
            return CList;
        }


        public bool IsThereRoomInTheCourse(string semester, string courseNum)
        {
            bool ret = false;
            try
            {
                string sql = "select Capacity from CoursesOffered where CourseNum=@CourseNum and " +
                    "SemesterId=@SemesterId";
                List<SqlParameter> PList = new List<SqlParameter>();
                DBHelper.AddSqlParam(PList, "@CourseNum", SqlDbType.VarChar, courseNum, 50);
                DBHelper.AddSqlParam(PList, "@SemesterId",  SqlDbType.VarChar, semester, 20);
                object objCap = DataLayer.DataAccess.GetSingleAnswer(sql, PList);
                if (objCap != null)
                {
                    int capacity = int.Parse(objCap.ToString());
                    int enrollCount = GetEnrollmentCount(semester, courseNum);
                    if (enrollCount < capacity)
                        ret = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

    }
}
