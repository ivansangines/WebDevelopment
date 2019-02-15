using StudentWebApp.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.BusinessLayer
{
    class BusinessStudents : IBusinessStudents
    {
        /*
        RepositoryCourses repCourses = new RepositoryCourses();
        RepositoryStudents repStudents = new RepositoryStudents();
        */

        IRepositoryCourses _irc = null;
        IRepositoryStudents _irs = null;

        public BusinessStudents()
        {
            _irc = new RepositoryCourses();
            _irs = new RepositoryStudents();
        }

        public BusinessStudents(IRepositoryCourses irc, IRepositoryStudents irs)
        {
            _irc = irc;
            _irs = irs;
        }

        public BusinessStudents(IRepositoryCourses irc)
        {
            _irc = irc;
            _irs = new RepositoryStudents();
        }

        public BusinessStudents(IRepositoryStudents irs)
        {
            _irc = new RepositoryCourses();
            _irs = irs;
        }

        public bool RegisterStudent(long studentId, string semester, string courseNum)
        {
            bool ret = false;
            try
            {
                if (_irs.DoesStudentExist(studentId))
                {
                    if (_irs.HasStudentTakenPreRequisteCourses(studentId, courseNum, 2.0f))
                    {
                        if (_irc.IsThereRoomInTheCourse(semester, courseNum))
                            ret = _irs.RegisterStudent(studentId, semester, courseNum);
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
