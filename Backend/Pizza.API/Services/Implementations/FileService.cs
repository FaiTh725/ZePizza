using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Pizza.API.Models.File;
using Pizza.API.Services.Interfaces;

namespace Pizza.API.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly BlobServiceClient blobServiceClient;

        public FileService(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }

        public async Task Delete(Guid fileId, string containerName, CancellationToken cancellationToken = default)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            var blobClient = containerClient.GetBlobClient(fileId.ToString());

            await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);
        }

        public async Task<FileResponse> Download(Guid fileId, string containerName, CancellationToken cancellationToken = default)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            var blobClient = containerClient.GetBlobClient(fileId.ToString());

            var response = await blobClient.DownloadContentAsync(cancellationToken);

            return new FileResponse
            {
                Stream = response.Value.Content.ToStream(),
                ContentType = response.Value.Details.ContentType
            };
        }

        public async Task<Guid> UploadFile(Stream stream, string containerName, string contentType, CancellationToken cancellationToken = default)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            var fileId = Guid.NewGuid();
            var blobClient = containerClient.GetBlobClient(fileId.ToString());

            await blobClient.UploadAsync(
                stream, 
                new BlobHttpHeaders { ContentType = contentType},
                cancellationToken: cancellationToken);

            return fileId;
        }
    }
}
