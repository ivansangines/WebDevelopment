using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorIdentity.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace RazorIdentity.Pages.Admin.AppRoles
{
    public class CreateModel : PageModel
    {
        private readonly RazorIdentity.Models.ComplexDb2Context _context;

        public CreateModel(IServiceProvider serviceProvider, RazorIdentity.Models.ComplexDb2Context context)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        IServiceProvider _serviceProvider;

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AspNetRoles AspNetRoles { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var RoleManager =_serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager =_serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            //add role to the database received in BidProperty
            IdentityResult roleResult;
            var roleCheck = await RoleManager.RoleExistsAsync(AspNetRoles.Name);
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole(AspNetRoles.Name));
            }
            return RedirectToPage("./Index");

            /*
            _context.AspNetRoles.Add(AspNetRoles);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            */
        }
    }
}