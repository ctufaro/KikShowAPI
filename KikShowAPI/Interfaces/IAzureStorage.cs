using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KikShowAPI.Interfaces
{
    public interface IAzureStorage
    {
        Task<bool> UploadToStorage(Stream stream, string file);
        Task<MemoryStream> DownloadFromStorage(string file);
        Task<bool> DeleteFromStorage(string file);
    }

   
}
