using System;
using System.Collections.Generic;

namespace StDb2EFRP.Models
{
    public partial class CoursesTaken
    {
        public int StudentId { get; set; }
        public string CourseNum { get; set; }
        public double? Grade { get; set; }
        public int Snum { get; set; }

        public virtual Courses CourseNumNavigation { get; set; }
        public virtual Students Student { get; set; }
    }
}
