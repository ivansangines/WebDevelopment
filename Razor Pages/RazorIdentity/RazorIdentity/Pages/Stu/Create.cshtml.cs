using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorIdentity.Models;

namespace RazorIdentity.Pages.Stu
{
    public class CreateModel : PageModel
    {
        private readonly RazorIdentity.Models.ComplexDb2Context _context;

        public CreateModel(RazorIdentity.Models.ComplexDb2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Students Students { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Students.Add(Students);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}