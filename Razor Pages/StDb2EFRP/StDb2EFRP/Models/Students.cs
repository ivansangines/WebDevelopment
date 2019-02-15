using System;
using System.Collections.Generic;

namespace StDb2EFRP.Models
{
    public partial class Students
    {
        public Students()
        {
            CoursesTaken = new HashSet<CoursesTaken>();
            Enrollment = new HashSet<Enrollment>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Major { get; set; }

        public virtual ICollection<CoursesTaken> CoursesTaken { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}
