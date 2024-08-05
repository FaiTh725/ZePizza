using Pizza.API.Models.File;

namespace Pizza.API.Services.Interfaces
{
    public interface IFileService
    {
        Task<Guid> UploadFile(Stream stream, string containerName, string contentType, CancellationToken cancellationToken = default);

        Task<FileResponse> Download(Guid fileId, string containerName, CancellationToken cancellationToken = default);

        Task Delete(Guid fileId, string containerName, CancellationToken cancellationToken = default);
    }
}
