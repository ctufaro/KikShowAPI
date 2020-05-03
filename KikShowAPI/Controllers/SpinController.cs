using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KikShowAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KikShowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpinController : ControllerBase
    {
        // POST: api/Spin
        [HttpPost]
        public async Task<ObjectResult> Post([FromForm]UserSpin userSpin)
        {
            string name = userSpin.Name;
            var video = userSpin.Video;
            if (video.Length > 0)
            {        
                Storage storage = new Storage();
                using (var stream = video.OpenReadStream())
                {
                    await storage.UploadToStorage(stream, video.FileName);
                }

            }
            return Ok(new { status = true, message = "User Video Posted Successfully!!" });
        }
    }
}
