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
    public class ManageUsersModel : PageModel
    {
        private readonly RazorIdentity.Models.ComplexDb2Context _context;
        public ManageUsersModel(RazorIdentity.Models.ComplexDb2Context context)
        {
            _context = context;
        }
        public IList<UserVM> UserList { get; set; }
        public async Task OnGetAsync()
        {
            var res = await _context.AspNetUsers.ToListAsync();
            UserList = (from item in res
                        select new UserVM
                        {
                            UserName = item.UserName,
                            Email = item.Email,
                            Id = item.Id
                        }).ToList<UserVM>();
        }
    }
}
