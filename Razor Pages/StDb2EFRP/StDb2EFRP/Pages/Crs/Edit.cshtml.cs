using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StDb2EFRP.Models;

namespace StDb2EFRP.Pages.Crs
{
    public class EditModel : PageModel
    {
        private readonly StDb2EFRP.Models.StDb2SqlContext _context;

        public EditModel(StDb2EFRP.Models.StDb2SqlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Courses Courses { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Courses = await _context.Courses.FirstOrDefaultAsync(m => m.CourseNum == id);

            if (Courses == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Courses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursesExists(Courses.CourseNum))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CoursesExists(string id)
        {
            return _context.Courses.Any(e => e.CourseNum == id);
        }
    }
}
