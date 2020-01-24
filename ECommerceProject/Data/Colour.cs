using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.Data
{
    public class Colour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        public ICollection<ProductColour> GetProductColours { get; set; }
    }
}
