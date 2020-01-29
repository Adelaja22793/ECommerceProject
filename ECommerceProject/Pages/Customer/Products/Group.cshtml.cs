using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace ECommerceProject.Pages.Customer.Products
{
    public class GroupModel : PageModel
    {
        private readonly ECommerceProject.Data.ApplicationDbContext _context;

        public GroupModel(ECommerceProject.Data.ApplicationDbContext context)
        {
            _context = context;
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
    }
}