using KikShowAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KikShowAPI.Models
{
    public class Storage : IAzureStorage
    {
        AzureStorageConfig _config;
        public Storage()
        {
            //set properties here
            _config = new AzureStorageConfig();            
        }

        public async Task<bool> DeleteFromStorage(string file)
        {
            await Task.Delay(1);
            return true;
        }

        public async Task<MemoryStream> DownloadFromStorage(string file)
        {
            await Task.Delay(1);
            return null;
        }

        public async Task<bool> UploadToStorage(Stream stream, string file)
        {
            await Task.Delay(1);
            return true;
        }
    }
}
