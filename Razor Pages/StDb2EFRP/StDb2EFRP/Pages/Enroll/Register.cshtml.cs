using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StDb2EFRP.Models;

namespace StDb2EFRP.Pages.Enroll
{
    public class RegisterModel : PageModel
    {
        private readonly StDb2EFRP.Models.StDb2SqlContext _context;

        public RegisterModel(StDb2EFRP.Models.StDb2SqlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Enrollment Enroll { get; set; }

        public SelectList CNum { get; private set; }

        public string Msg = "";

        public IActionResult OnGet()
        {
            //ViewData["CourseNum"] = new SelectList(_context.Courses, "CourseNum", "CourseNum");
            //ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            IList<Courses> AllCourses =  _context.Courses.OrderBy(c => c.CourseNum).ToList();
            CNum = new SelectList(AllCourses, "CourseNum", "CourseNum");
            Enroll = new Enrollment();
            Enroll.SectionNum = 1;
            Enroll.Cnum = (int)AllCourses[0].CreditHours;
            return Page();

        }

        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {


                IList<Courses> AllCourses = _context.Courses.OrderBy(c => c.CourseNum).ToList();
                CNum = new SelectList(AllCourses, "CourseNum", "CourseNum");

                var preReq = (from c in _context.Prerequisites where c.CourseNum == Enroll.CourseNum select c.PrereqCnum).ToList();
                var coursesTaken = (from ct in _context.CoursesTaken where ct.StudentId == Enroll.StudentId select ct.CourseNum).ToList();
                bool prereq = false;
                int count = 0;
                for (int i = 0; i < preReq.Count; i++)
                {
                    for (int j = 0; j < coursesTaken.Count; j++)
                    {
                        if (preReq[i].Equals(coursesTaken[j]))
                        {
                            count++;
                        }
                    }
                }
                if (preReq.Count == count) { prereq = true; }
                if (prereq)
                {
                    _context.Enrollment.Add(Enroll);
                    await _context.SaveChangesAsync();
                    Msg = "Successful...";
                    return RedirectToPage("./Enrollm");
                }
                else
                {
                    Msg = "Missing Prerequisites for this course";
                    return RedirectToPage("./Register");
                }

            }
            catch (Exception)
            {
               
                Msg = "Error found...";
                return RedirectToPage("./Register");

            }
            
            
        }
    }
}