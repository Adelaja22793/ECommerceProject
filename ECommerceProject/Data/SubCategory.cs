using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.Data
{
    public class SubCategory
    {
        public int Id { get; set; }

        [DisplayName("Sub-Category")]
        public string Name { get; set; }
        [DisplayName("Category Image")]
        public string BannerImage { get; set; }

        //Establishing one-many relationship between
        //MainCategory and SubCategory
        //or navigation properties
        [DisplayName("Main Category")]
        public int MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }
        public List<Product> Products { get; set; }
    }
}
