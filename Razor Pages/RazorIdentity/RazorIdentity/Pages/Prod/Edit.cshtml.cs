using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorIdentity.Models;

namespace RazorIdentity.Pages.Prod
{
    public class EditModel : PageModel
    {
        private readonly RazorIdentity.Models.ComplexDb2Context _context;

        public EditModel(RazorIdentity.Models.ComplexDb2Context context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
           ViewData["ProductColorId"] = new SelectList(_context.ProductColors, "ProductColorId", "Color");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(Products.ProductId))
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

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
