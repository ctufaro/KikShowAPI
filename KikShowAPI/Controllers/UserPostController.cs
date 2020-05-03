using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KikShowAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KikShowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPostController : ControllerBase
    {
        // GET: api/UserPost
        [HttpGet]
        public async Task<List<UserPost>> Get()
        {
            return await new UserPost().SelectUserPostsAsync();
        }

        // GET: api/UserPost/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserPost
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/UserPost/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
