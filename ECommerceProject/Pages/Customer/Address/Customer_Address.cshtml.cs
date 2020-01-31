using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Pages.Customer.Address
{
    public class Customer_AddressModel : PageModel
    {
        private readonly ECommerceProject.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public Customer_AddressModel(ECommerceProject.Data.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<Data.Address> Addresses { get; set; }
        [BindProperty]
        public Data.Address Address { get; set; }
        public bool MyAddress { get; set; }
        public string Message { get; set; }
        public string LoginUser { get; set; }
        public async Task OnGetAsync()
        {

            LoginUser = (await GetCurrentUserAsync()).Id;
            //var logUser = await GetCurrentUserAsync();
            //var userid = logUser.Id;
            //Address.CustomerId = userid;
            //var ids = _userManager.GetUserId(User);
            //MyAddress =  _context.Addresses
            //    .Where(x=>x.CustomerId == userid)
            //    .Any();
            //.Where(x=>x.)
            Addresses = await _context.Addresses
                .Where(p => p.CustomerId == LoginUser).ToListAsync();
            if (Addresses != null)
            {
                Message = "No Address has been created for the selected course, class and session";
            }
            
        }
        private Task<IdentityUser> GetCurrentUserAsync() =>
           _userManager.GetUserAsync(HttpContext.User);
    }
    
}