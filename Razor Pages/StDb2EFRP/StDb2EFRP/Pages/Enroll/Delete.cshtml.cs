using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StDb2EFRP.Models;

namespace StDb2EFRP.Pages.Enroll
{
    public class DeleteModel : PageModel
    {
        private readonly StDb2EFRP.Models.StDb2SqlContext _context;

        public DeleteModel(StDb2EFRP.Models.StDb2SqlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, string cnum)
        {
            if (cnum == null)
            {
                return NotFound();
            }

            Enrollment = await _context.Enrollment
                .Include(e => e.CourseNumNavigation)
                .Include(e => e.Student).FirstOrDefaultAsync(m => m.CourseNum == cnum && m.StudentId == id);

            if (Enrollment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            // obtain StudentId and CourseNum from the Enrollment field which is
            // bound to the form via hidden fields
            int studentId = Enrollment.StudentId; // maps to the hidden field in the delete form
            string courseNum = Enrollment.CourseNum;// maps to the hidden field in the delete form
            if (id == null)
            {
                return NotFound();
            }
            Enrollment = await _context.Enrollment.FindAsync(Enrollment.CourseNum,Enrollment.StudentId);
            // the parameters above have to be in the order of coursenum and studentid
            if (Enrollment != null)
            {
                _context.Enrollment.Remove(Enrollment);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Enrollm");
        }
    }
}
