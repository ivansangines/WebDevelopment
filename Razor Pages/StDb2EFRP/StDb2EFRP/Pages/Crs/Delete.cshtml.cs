using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StDb2EFRP.Models;

namespace StDb2EFRP.Pages.Crs
{
    public class DeleteModel : PageModel
    {
        private readonly StDb2EFRP.Models.StDb2SqlContext _context;

        public DeleteModel(StDb2EFRP.Models.StDb2SqlContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Courses = await _context.Courses.FindAsync(id);

            if (Courses != null)
            {
                _context.Courses.Remove(Courses);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
