using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorIdentity.Models;

namespace RazorIdentity.Pages.Stu
{
    public class DeleteModel : PageModel
    {
        private readonly RazorIdentity.Models.ComplexDb2Context _context;

        public DeleteModel(RazorIdentity.Models.ComplexDb2Context context)
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
