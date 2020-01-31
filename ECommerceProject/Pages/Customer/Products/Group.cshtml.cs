using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace ECommerceProject.Pages.Customer.Products
{
    //Authorizing that only login in user can assess
    //[Authorize(Roles = "Customer")]
    public class GroupModel : PageModel
    {
        private readonly ECommerceProject.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public GroupModel(ECommerceProject.Data.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public SubCategory SubCat { get; set; }
        public List<MainCategory> listMainCategory { get; set; }
        public async Task<IActionResult> OnGetAsync(int? subGrpId)
        {
            
            if (subGrpId == null)
            {
                return NotFound();
            }
            SubCat = await _context.SubCategories.Include(c =>c.Products)
                .ThenInclude(m => m.Images)
                .FirstOrDefaultAsync(c => c.Id == subGrpId.Value);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                //create a new cart
                var cart = new Cart();
                cart.ProductId = product.Id;
                cart.Quantity = 1;
                cart.CartState = Enumerations.CartState.InCart;



            }
            return Page();

        }
        private Task<IdentityUser> GetCurrentUserAsync() =>
            _userManager.GetUserAsync(HttpContext.User);
        
    }
}