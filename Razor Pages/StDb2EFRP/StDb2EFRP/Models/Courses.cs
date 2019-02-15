using System;
using System.Collections.Generic;

namespace StDb2EFRP.Models
{
    public partial class Courses
    {
        public Courses()
        {
            CoursesTaken = new HashSet<CoursesTaken>();
            Enrollment = new HashSet<Enrollment>();
            PrerequisitesCourseNumNavigation = new HashSet<Prerequisites>();
            PrerequisitesPrereqCnumNavigation = new HashSet<Prerequisites>();
        }

        public string CourseNum { get; set; }
        public string CourseName { get; set; }
        public int? CreditHours { get; set; }

        public virtual CoursesOffered CoursesOffered { get; set; }
        public virtual ICollection<CoursesTaken> CoursesTaken { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
        public virtual ICollection<Prerequisites> PrerequisitesCourseNumNavigation { get; set; }
        public virtual ICollection<Prerequisites> PrerequisitesPrereqCnumNavigation { get; set; }
    }
}
