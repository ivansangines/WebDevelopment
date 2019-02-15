using System;
using System.Collections.Generic;

namespace StDb2EFRP.Models
{
    public partial class CoursesOffered
    {
        public string CourseNum { get; set; }
        public int? NumRegistered { get; set; }
        public int? Capacity { get; set; }

        public virtual Courses CourseNumNavigation { get; set; }
    }
}
