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
        public async Task<ObjectResult> Post([FromForm]UserPostData userPD)
        {
            if (userPD.Motion.Length > 0)
            {
                Storage storage = new Storage();
                using (var stream = userPD.Motion.OpenReadStream())
                {
                    //uploading motion to azure
                    await storage.UploadToStorage(stream, userPD.Motion.FileName);
                }
            }
            if (userPD.Image.Length > 0)
            {
                Storage storage = new Storage();
                using (var stream = userPD.Image.OpenReadStream())
                {
                    //uploading motion to azure
                    await storage.UploadToStorage(stream, userPD.Image.FileName);
                }
            }
            try
            {
                await new UserPost().InsertUserPostAsync(userPD);
                return Ok(new { status = true, message = "User Posted Successfully!!" });
            }
            catch(Exception e)
            {
                return NotFound(new { status = false, message = $"WebAPI error:{e.ToString()}" });
            }
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
