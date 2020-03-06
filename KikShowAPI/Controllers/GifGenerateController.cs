using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KikShowAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KikShowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GifGenerateController : ControllerBase
    {
        // GET: api/GifGenerate
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GifGenerate/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GifGenerate
        [HttpPost]
        public async void Post(List<IGifFile> data)
        {
            //??
            await Task.Delay(1);
        }

        // PUT: api/GifGenerate/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<string> Delete(List<IGifFile> data)
        {
            await Task.Delay(1);
            return "";
        }
    }
}
