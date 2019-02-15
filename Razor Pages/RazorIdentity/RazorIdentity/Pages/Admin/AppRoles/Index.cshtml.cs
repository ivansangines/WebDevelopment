using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorIdentity.Models;

namespace RazorIdentity.Pages.Admin.AppRoles
{
    public class IndexModel : PageModel
    {
        private readonly RazorIdentity.Models.ComplexDb2Context _context;

        public IndexModel(RazorIdentity.Models.ComplexDb2Context context)
        {
            _context = context;
        }

        public IList<AspNetRoles> AspNetRoles { get;set; }

        public async Task OnGetAsync()
        {
            AspNetRoles = await _context.AspNetRoles.ToListAsync();
        }
    }
}
