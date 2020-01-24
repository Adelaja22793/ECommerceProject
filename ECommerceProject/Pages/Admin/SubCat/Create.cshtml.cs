using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommerceProject.Data;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ECommerceProject.Pages.Admin.SubCat
{
    public class CreateModel : PageModel
    {
        private readonly ECommerceProject.Data.ApplicationDbContext _context;
        [BindProperty]
        public IFormFile BannerImage { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public CreateModel(ECommerceProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MainCategoryId"] = new SelectList(_context.MainCategories, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public SubCategory SubCategory { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (BannerImage != null && BannerImage.Length>0)
            {
                var filename = DateTime.Now.Ticks.ToString() + BannerImage.FileName;
                var filepath = Path.Combine(Directory.GetCurrentDirectory(),
                    @"wwwroot\productimages", filename);
                await BannerImage.CopyToAsync(new FileStream(filepath, FileMode.Create));

                SubCategory.BannerImage = filename;
                _context.SubCategories.Add(SubCategory);
                await _context.SaveChangesAsync();

            }
            else
            {
                //Error = $"{Type.Name} already exists.";
                Error = $"{SubCategory.BannerImage} cannot be empty.";
            }
            //Assignment, add message for success and fail

            return RedirectToPage("./Index");
        }
    }
}