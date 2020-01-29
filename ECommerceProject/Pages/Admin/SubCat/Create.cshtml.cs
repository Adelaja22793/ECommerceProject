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
            ViewData["MainCategoryId"] = new SelectList(_context.MainCategories, "Id", "Name");
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
            var BannerImages = BannerImage;
            //var _DBContext = new ECommerceProjectContext();
            if (BannerImage != null && BannerImage.Length>0)
            {
                var filename = DateTime.Now.Ticks.ToString() + BannerImage.FileName;
                var filepath = Path.Combine(Directory.GetCurrentDirectory(),
                    @"wwwroot\productimages", filename);
                await BannerImage.CopyToAsync(new FileStream(filepath, FileMode.Create));

                SubCategory.BannerImage = filename;
                _context.SubCategories.Add(SubCategory);
                await _context.SaveChangesAsync();
                Message = $"{SubCategory.Name} Successfully Saved";

            }
            //else if (SubCategory.Any(x =>x.na))
            //{

            //}
            else
            {
                //Error = $"{Type.Name} already exists.";
                Error = $"{SubCategory.BannerImage} cannot be empty.";
                return Page();
            }

            //var _DBContext = new TestEcommerceContext();
            //if (_DBContext.Type.Any(x => x.Name == Type.Name))
            //{
            //    Error = $"{Type.Name} already exists.";
            //}
            //else
            //{
            //    _DBContext.Type.Add(Type);
            //    _DBContext.SaveChanges();
            //    Message = $"{Type.Name} Successfully Saved";
            //    //Error = $"{Type.Name}Error Occoured While Saving";

            //}
            //Assignment, add message for success and fail

            return RedirectToPage("./Index");
        }
    }
}