using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KikShowAPI.Models
{
    public class UserSpin
    {
        public string Name { get; set; }
        public IFormFile Video { get; set; }
    }
}
