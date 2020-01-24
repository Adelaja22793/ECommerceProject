using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.Data
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BannerImage { get; set; }

        //Establishing one-many relationship between
        //MainCategory and SubCategory
        //or navigation properties
        public int MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }
        public List<Product> Products { get; set; }
    }
}
