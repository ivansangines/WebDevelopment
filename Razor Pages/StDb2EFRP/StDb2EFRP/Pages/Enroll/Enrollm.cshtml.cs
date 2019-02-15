using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StDb2EFRP.Models;

namespace StDb2EFRP.Pages.Enroll
{
    public class EnrollmModel : PageModel
    {
        private readonly StDb2EFRP.Models.StDb2SqlContext _context;

        public EnrollmModel(StDb2EFRP.Models.StDb2SqlContext context)
        {
            _context = context;
        }

        public SelectList CSList { get; private set; }

        [BindProperty]
        public string SelectedCourse { get; set; }

        public IList<EnrollmentVm> EList { get; set; }

        public async Task OnGetAsync()
        {
            // get courses offered------
            IList<CoursesOffered> CoursesOfferedList = await _context.CoursesOffered.OrderBy(c => c.CourseNum).ToListAsync();

            // get enrollment for first course
            string firstCourse = "";
            EList = new List<EnrollmentVm>();
            IList<Enrollment> EnrollList = null;
            if (CoursesOfferedList.Count > 0)
            {
                firstCourse = CoursesOfferedList[0].CourseNum;
                EnrollList = await _context.Enrollment
                    .Include(e => e.CourseNumNavigation)
                    .Include(e => e.Student).Where(e => e.CourseNum == firstCourse).ToListAsync();
            }
            // convert to EnrollmentVM list
            foreach (var item in EnrollList)
            {
                EnrollmentVm evm = new EnrollmentVm
                {
                    FirstName = item.Student.FirstName,
                    LastName = item.Student.LastName,
                    Credits = (int)item.CourseNumNavigation.CreditHours,
                    StudentId = item.StudentId
                };
                EList.Add(evm);
            }
            SelectedCourse = firstCourse;
            CSList = new SelectList(CoursesOfferedList, "CourseNum", "CourseNum");
        }

        public async Task OnPostAsync()
        {
            // get courses offered------
            IList<CoursesOffered> CoursesOfferedList = await _context.CoursesOffered.OrderBy(c => c.CourseNum).ToListAsync();
            // get enrollment for first course
            string selCourse = SelectedCourse;
            EList = new List<EnrollmentVm>();
            IList<Enrollment> EnrollList = null;
            if (CoursesOfferedList.Count > 0)
            {
                EnrollList = await _context.Enrollment
                .Include(e => e.CourseNumNavigation)
                .Include(e => e.Student).Where(e => e.CourseNum ==selCourse).ToListAsync();
            }
            // convert to EnrollmentVM list
            foreach (var item in EnrollList)
            {
                EnrollmentVm evm = new EnrollmentVm
                {
                    FirstName = item.Student.FirstName,
                    LastName = item.Student.LastName,
                    Credits = (int)item.CourseNumNavigation.CreditHours,
                    StudentId = item.StudentId
                };
                EList.Add(evm);
            }
            SelectedCourse = selCourse;
            CSList = new SelectList(CoursesOfferedList, "CourseNum", "CourseNum");
        }

    }

}
