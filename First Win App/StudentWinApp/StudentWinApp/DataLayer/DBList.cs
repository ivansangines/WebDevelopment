using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWinApp.DataLayer
{
    class DBList
    {
        public static List<T> GetList<T>(DataTable dt)
            where T : IEntity, new()
        {  // will do conversion from dt to List<> for reference types
            List<T> TList = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                T t1 = new T();
                // populate the columns from dr into the fields of the t1
                // delegate the work of populating t1 to the class T
                t1.PopulateFields(dr);
                TList.Add(t1);
            }
            return TList;
        }

        public static List<T> GetListValueType<T>(DataTable dt, string colname)
            where T : IConvertible  // will do conversion from dt to List<>for value types including string
        {
            List<T> TList = new List<T>();
            foreach (DataRow dr in dt.Rows)
                TList.Add((T)dr[colname]);
            return TList;
        }
    }
}
