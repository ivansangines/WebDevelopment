using StudentWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentWebApp.DataLayer
{
    class RepositoryInstructors : IRepositoryInstructors
    {
        IDataAccess _idac = null;

        public RepositoryInstructors()
        {
            _idac = new DataAccess();
        }

        public RepositoryInstructors(DataAccess idac)
        {
            _idac = idac;
        }

        public List<Instructors> GetInstructors()
        {
            List<Instructors> IList = new List<Instructors>();

            try
            {

                string sql = "select i.FirstName, i.LastName, i.Telephone, d.DepartmentName as Department from Instructors i " +
                    "inner join Departments d on i.DepartmentId=d.DepartmentID";
                          

                DataTable dt = _idac.GetManyRowsCols(sql, null);

                IList = DBList.GetList<Instructors>(dt);               
            }
            catch (Exception)
            {
                throw;
            }

            return IList;

        }
    }
}