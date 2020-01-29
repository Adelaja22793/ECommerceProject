using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceProject.API
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ECommerceProject.Data.ApplicationDbContext _context;

        public CategoryController(ECommerceProject.Data.ApplicationDbContext context)
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
        //[HttpGet("{id}")]
        [HttpGet("ByName")]
        public List<MainCategory> MainCategories()
        {
            var MainCat = _context.MainCategories.ToList();
            return MainCat;
        }
        [HttpGet("ById")]
        public MainCategory GetMainCategoriesBy([FromQuery]int id)
        {
            var MainCatId = _context.MainCategories.FirstOrDefault(x => x.Id == id);
            return MainCatId;
        }
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
