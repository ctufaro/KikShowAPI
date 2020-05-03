using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KikShowAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KikShowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobsController : ControllerBase
    {
        // GET: api/Blobs
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Blobs/5
        //[HttpGet("{id}")]
        //public async Task<IFormFile> Get(string id)
        //{
        //    var stream = await new Storage().DownloadFromStorage(id);
        //    return new FormFile(stream, 0, stream.Length, id, id); ;
        //}

        [HttpGet("{id}")]
        public async Task<HttpResponseMessage> Get(string id)
        {
            // IMPORTANT: This must return HttpResponseMessage instead of IHttpActionResult

            try
            {
                var result = await new Storage().DownloadFromStorage(id);
                if (result == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                // Reset the stream position; otherwise, download will not work
                result.Position = 0;

                // Create response message with blob stream as its content
                var message = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(result)
                };

                // Set content headers
                message.Content.Headers.ContentLength = result.Length;
                message.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
                message.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = id,
                    Size = result.Length
                };

                return message;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(ex.Message)
                };
            }
        }

        // POST: api/Blobs
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Blobs/5
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
