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
    public class StorageController : ControllerBase
    {

        // POST: api/Storage
        [HttpPost]
        public async Task<string> Post([FromForm(Name = "body")]IFormFile formData)
        {
            string file = Guid.NewGuid().ToString() + ".jpg";
            Storage storage = new Storage();
            using (var stream = formData.OpenReadStream())
            {
                await storage.UploadToStorage(stream, file);
            }

            return file;
        }
 
    }
}
