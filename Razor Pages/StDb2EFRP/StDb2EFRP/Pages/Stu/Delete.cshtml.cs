using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StDb2EFRP.Models;

namespace StDb2EFRP.Pages.Stu
{
    public class DeleteModel : PageModel
    {
        private readonly StDb2EFRP.Models.StDb2SqlContext _context;

        public DeleteModel(StDb2EFRP.Models.StDb2SqlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Students Students { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Students = await _context.Students.FirstOrDefaultAsync(m => m.StudentId == id);

            if (Students == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Students = await _context.Students.FindAsync(id);

            if (Students != null)
            {
                _context.Students.Remove(Students);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
