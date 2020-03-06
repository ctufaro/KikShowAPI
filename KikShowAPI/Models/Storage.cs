using KikShowAPI.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
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
            CloudBlockBlob blockBlob = GetBlob(file);
            return await blockBlob.DeleteIfExistsAsync();
        }

        public async Task<MemoryStream> DownloadFromStorage(string file)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                CloudBlockBlob blockBlob = GetBlob(file);
                await blockBlob.DownloadToStreamAsync(stream);
                stream.Position = 0;
                return stream;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UploadToStorage(Stream stream, string file)
        {
            try
            {
                CloudBlockBlob blockBlob = GetBlob(file);
                await blockBlob.UploadFromStreamAsync(stream);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public CloudBlockBlob GetBlob(string fileName)
        {
            // Goody Gumdrops
            AzureStorageConfig _storageConfig = new AzureStorageConfig();
            _storageConfig.AccountName = Config.AccountName;
            _storageConfig.AccountKey = Config.AccountKey;
            _storageConfig.ImageContainer = Config.ImageContainer;

            // Create storagecredentials object by reading the values from the configuration (appsettings.json)
            StorageCredentials storageCredentials = new StorageCredentials(_storageConfig.AccountName, _storageConfig.AccountKey);

            // Create cloudstorage account by passing the storagecredentials
            CloudStorageAccount storageAccount = new CloudStorageAccount(storageCredentials, true);

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Get reference to the blob container by passing the name by reading the value from the configuration (appsettings.json)
            CloudBlobContainer container = blobClient.GetContainerReference(_storageConfig.ImageContainer);

            // Get the reference to the block blob from the container
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            return blockBlob;
        }
    }
}
