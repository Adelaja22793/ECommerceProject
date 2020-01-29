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
    public class ValuesController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        //[HttpGet("{id}")]
        [HttpGet("ByName")]
        public string Get([FromQuery]int id, [FromQuery] string name)
        {
            
            return $"Your Name is {name} and your ID is : {id}";
            //return firstAddress();
        }
        // GET api/<controller>/5
        //[HttpGet("{id}")]
        [HttpGet("GetAddressById")]
        public Address GetAddressById([FromQuery]int id)
        {
            //this is the database
            var listOfAddress = new List<Address>
            {
                new Address
                {
                    Id = 1,
                    Title = "Home",
                    ActualAddress = "6, Johnson Street",
                    State = "Lagos",
                    CustomerId = "2"
                },
                new Address
                {
                    Id = 1,
                    Title = "Home",
                    ActualAddress = "6, Coker Street",
                    State = "Lagos",
                    CustomerId = "2"
                },
                new Address
                {
                    Id = 1,
                    Title = "Home",
                    ActualAddress = "6, Potential Street",
                    State = "Lagos",
                    CustomerId = "2"
                },

            };

            var requestedAddress = listOfAddress.FirstOrDefault(x => x.Id == id);
            return requestedAddress;
        }
// GET api/<controller>/5
        //[HttpGet("{id}")]
        [HttpGet("AddressByIdAll")]
        public List<Address> GetAddressByIdAll([FromQuery]int id)
        {
            //this is the database
            var listOfAddress = new List<Address>
            {
                new Address
                {
                    Id = 1,
                    Title = "Home",
                    ActualAddress = "6, Johnson Street",
                    State = "Lagos",
                    CustomerId = "2"
                },
                new Address
                {
                    Id = 1,
                    Title = "Home",
                    ActualAddress = "6, Coker Street",
                    State = "Lagos",
                    CustomerId = "2"
                },
                new Address
                {
                    Id = 1,
                    Title = "Home",
                    ActualAddress = "6, Potential Street",
                    State = "Lagos",
                    CustomerId = "2"
                },

            };

            //var requestedAddresss = listOfAddress.ToList();
            return listOfAddress;
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
