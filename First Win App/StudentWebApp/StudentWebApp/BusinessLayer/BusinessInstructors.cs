using StudentWebApp.DataLayer;
using StudentWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebApp.BusinessLayer
{
    class BusinessInstructors:IBusinessInstructors
    {
        IRepositoryInstructors _iri = null;

        public BusinessInstructors()
        {
            _iri = new RepositoryInstructors();
        }

        public BusinessInstructors(RepositoryInstructors iri)
        {
            _iri = iri;
        }

        public List<Instructors> GetInstructors()
        {
            return _iri.GetInstructors();
        }
    }
}