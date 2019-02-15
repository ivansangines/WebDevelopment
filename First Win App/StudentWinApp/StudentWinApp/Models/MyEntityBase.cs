using StudentWinApp.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace StudentWinApp.Models
{
    class MyEntityBase : IEntity
    {
        public void PopulateFields(DataRow dr)
        {
            // use reflection to populate the fields of this class from DataRow
            Type tp = this.GetType();
            foreach (PropertyInfo pi in tp.GetProperties())
                pi.SetValue(this, dr[pi.Name]);
        }
    }
}
