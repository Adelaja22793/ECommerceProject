using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("New Price")]
        public double Price { get; set; }
        [DisplayName("Old Price")]
        public double OldPrice { get; set; }
        [DisplayName("Sub Category")]
        public int SubCategoryId { get; set; }
        

        public SubCategory SubCategory { get; set; }
        public IList<ProductColour> ProductColours { get; set; }
        public IList<Image> Images { get; set; }
    }
}
