using KikShowAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KikShowAPI.Models
{
    public class GifGenerate : IGifGenerate
    {
        public async Task GenerateGif(List<IGifFile> files)
        {
            await Task.Delay(1);
        }
    }
}
