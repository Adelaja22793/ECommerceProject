using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommerceProject.Data;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject
{
    public class CreateModel : PageModel
    {
        private readonly ECommerceProject.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CreateModel(ECommerceProject.Data.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Address Address { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //cart.CustomerId = (await GetCurrentUserAsync()).Id
            var logUser = await GetCurrentUserAsync();
            var userid = logUser.Id;
            Address.CustomerId = userid;
            _context.Addresses.Add(Address);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        private Task<IdentityUser> GetCurrentUserAsync() =>
           _userManager.GetUserAsync(HttpContext.User);
    }
}