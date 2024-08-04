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
        // TODO Push container name in configuration setting
        private const string ContainerName = "pizza-products";

        public FileService(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }

        public async Task Delete(Guid fileId, CancellationToken cancellationToken = default)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(ContainerName);

            var blobClient = containerClient.GetBlobClient(fileId.ToString());

            await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);
        }

        public async Task<FileResponse> Download(Guid fileId, CancellationToken cancellationToken = default)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(ContainerName);

            var blobClient = containerClient.GetBlobClient(fileId.ToString());

            var response = await blobClient.DownloadContentAsync(cancellationToken);

            return new FileResponse
            {
                Stream = response.Value.Content.ToStream(),
                ContentType = response.Value.Details.ContentType
            };
        }

        public async Task<Guid> UploadFile(Stream stream, string contentType, CancellationToken cancellationToken = default)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(ContainerName);

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
