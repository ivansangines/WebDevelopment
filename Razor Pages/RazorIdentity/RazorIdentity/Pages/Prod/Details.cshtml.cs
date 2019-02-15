using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorIdentity.Models;

namespace RazorIdentity.Pages.Prod
{
    public class DetailsModel : PageModel
    {
        private readonly RazorIdentity.Models.ComplexDb2Context _context;

        public DetailsModel(RazorIdentity.Models.ComplexDb2Context context)
        {
            _context = context;
        }

        public Products Products { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductColor).FirstOrDefaultAsync(m => m.ProductId == id);

            if (Products == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
