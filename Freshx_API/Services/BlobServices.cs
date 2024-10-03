using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Freshx_API.Services
{
    public class BlobServices
    {
      private readonly BlobServiceClient _blobServiceClient;
    private readonly string _containerName;

        public BlobServices(IConfiguration configuration)
        {
            _blobServiceClient = new BlobServiceClient(configuration["AzureBlobStorage:ConnectionString"]);
            _containerName = configuration["AzureBlobStorage:ContainerName"];
        }


        // Thêm file
        public async Task<string> UploadFileAsync( string fileName, Stream content)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            await containerClient.CreateIfNotExistsAsync();
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(content, true);     
            return blobClient.Uri.ToString();
        }

        // Đọc file
        public async Task<Stream> DownloadFileAsync( string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            var response = await blobClient.DownloadAsync();
            return response.Value.Content;
        }

        // Sửa file (thực chất là ghi đè)
        public async Task<string> UpdateFileAsync(string fileName, Stream content)
        {
            return await UploadFileAsync( fileName, content);
        }

        // Xóa file
        public async Task DeleteFileAsync( string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync();
        }

        // Kiểm tra file tồn tại
        public async Task<bool> FileExistsAsync(string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            return await blobClient.ExistsAsync();
        }
    // Lấy toàn bộ file trong blob
    public async Task<List<string>> GetAllFilesAsync()
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        var files = new List<string>();

        await foreach (var blobItem in containerClient.GetBlobsAsync())
        {
            files.Add(blobItem.Name);
        }

        return files;
    }
    }
}
