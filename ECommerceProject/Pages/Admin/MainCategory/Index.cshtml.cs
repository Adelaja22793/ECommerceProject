using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECommerceProject.Data;

namespace ECommerceProject.Pages.Admin.MainCategory
{
    public class IndexModel : PageModel
    {
        private readonly ECommerceProject.Data.ApplicationDbContext _context;

        public IndexModel(ECommerceProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Data.MainCategory> MainCategory { get;set; }

        public async Task OnGetAsync()
        {
            MainCategory = await _context.MainCategories.ToListAsync();
        }
    }
}
