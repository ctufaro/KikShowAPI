using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KikShowAPI.Interfaces;
using KikShowAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KikShowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GifGenerateController : ControllerBase
    {
        // POST: api/GifGenerate
        [HttpPost]
        public async Task<string> Post(List<Snap> data)
        {
            Storage storage = new Storage();
            GifGenerate gifGenerate = new GifGenerate();
            string fileNameOnAzure = string.Empty;
            try
            {
                fileNameOnAzure = "sneaker_" + Guid.NewGuid().ToString() + ".gif";
                // Generate Animated GIF in Memory
                Stream stream = await gifGenerate.GenerateGif(data, storage);
                stream.Seek(0, SeekOrigin.Begin);
                // Upload from Memory to Azure
                await storage.UploadToStorage(stream, fileNameOnAzure);
                // Trash stream
                await stream.DisposeAsync();

                foreach (var dt in data)
                {
                    await storage.DeleteFromStorage(dt.FileName);
                }
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return "Uh-oh:" + error;
            }
            return fileNameOnAzure;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<string> Delete(List<Snap> data)
        {
            Storage storage = new Storage();
            string retval = "";
            try
            {
                foreach (var dt in data)
                {
                    await storage.DeleteFromStorage(dt.FileName);
                }
                retval = "Success";
            }
            catch (Exception e)
            {
                retval = "Uh-oh:" + e.ToString();
            }

            return retval;
        }
    }
}
