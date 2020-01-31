using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.Data
{
    public class Customer: IdentityUser
    {
        public string CardNumber { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
