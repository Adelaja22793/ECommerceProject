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
using ECommerceProject.UtilityMethods;

namespace ECommerceProject.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        private readonly ECommerceProject.Data.ApplicationDbContext _context;
        [BindProperty]
        public List<IFormFile> Product_Image { get; set; }
        //[BindProperty]
        //public IFormFile Product_Image2 { get; set; }
        //[BindProperty]
        //public IFormFile Product_Image3 { get; set; }
        //[BindProperty]
        //public IFormFile Product_Image4 { get; set; }
        //[BindProperty]
        //public IFormFile Product_Image5 { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public CreateModel(ECommerceProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

                _context.Products.Add(Product);
                await _context.SaveChangesAsync();

            var prdId = Product.Id;
            var images = new List<Image>();
            foreach (var img in Product_Image)
            {
                if (img !=null && img.Length>0)
                {
                    var filePath = await FileUpload.UploadFile(img, "productimages");
                    images.Add(new Image { Link = filePath, ProductId = prdId });
                }
            }
            _context.Images.AddRange(images);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}