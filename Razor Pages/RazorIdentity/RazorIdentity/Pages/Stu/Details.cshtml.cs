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
    public class DetailsModel : PageModel
    {
        private readonly RazorIdentity.Models.ComplexDb2Context _context;

        public DetailsModel(RazorIdentity.Models.ComplexDb2Context context)
        {
            _context = context;
        }

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
    }
}
