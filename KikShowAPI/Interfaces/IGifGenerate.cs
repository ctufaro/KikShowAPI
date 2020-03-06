using KikShowAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KikShowAPI.Interfaces
{
    interface IGifGenerate
    {
        Task<Stream> GenerateGif(List<Snap> files, IAzureStorage storage);
    }
}
