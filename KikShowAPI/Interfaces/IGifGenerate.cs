using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KikShowAPI.Interfaces
{
    interface IGifGenerate
    {
        Task GenerateGif(List<IGifFile> files);
    }
}
