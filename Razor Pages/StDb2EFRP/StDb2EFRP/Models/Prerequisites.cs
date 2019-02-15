using System;
using System.Collections.Generic;

namespace StDb2EFRP.Models
{
    public partial class Prerequisites
    {
        public string CourseNum { get; set; }
        public string PrereqCnum { get; set; }
        public int Cnum { get; set; }

        public virtual Courses CourseNumNavigation { get; set; }
        public virtual Courses PrereqCnumNavigation { get; set; }
    }
}
