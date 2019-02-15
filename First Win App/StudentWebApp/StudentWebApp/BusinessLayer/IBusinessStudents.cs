using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.BusinessLayer
{
    interface IBusinessStudents
    {
        bool RegisterStudent(long studentId, string semester, string courseNum);
    }
}
