using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KikShowAPI.Models
{
    public class UserPostData
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public IFormFile Motion { get; set; }
        public IFormFile Image { get; set; }
    }
}
