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

    public class AzureStorageConfig
    {
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
        public string QueueName { get; set; }
        public string ImageContainer { get; set; }
        public string ThumbnailContainer { get; set; }
    }
}
