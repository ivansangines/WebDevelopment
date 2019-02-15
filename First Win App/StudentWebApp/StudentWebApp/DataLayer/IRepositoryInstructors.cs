using StudentWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.DataLayer
{
    interface IRepositoryInstructors
    {
        List<Instructors> GetInstructors();
        
    }
}
