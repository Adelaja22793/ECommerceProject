using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceProject.API
{
    [Route("api/[controller]")]
    public class SubCategoryController : Controller
    {
        private readonly ECommerceProject.Data.ApplicationDbContext _context;

        public SubCategoryController(ECommerceProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // GET ALL SUBCATEGORY WITH THE MAIN CATEGORY ID
        [HttpGet("SubByMain")]
        public List<SubCategory> GetSubCategories([FromQuery] int id)
        {
            var Subcat = _context.SubCategories.Include(x => x.MainCategory)
                .Where(x => x.MainCategoryId == id).ToList();

            return Subcat;
        }
        // GET ALL SUBCATEGORY WITH ID
        [HttpGet("SubById")]
        public SubCategory GetSubCategoriesById([FromQuery] int id)
        {
            var Subcat = _context.SubCategories
                .FirstOrDefault(x => x.Id == id);
            
                return Subcat;
            
        }
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
