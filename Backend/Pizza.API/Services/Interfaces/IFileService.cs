using Pizza.API.Models.File;

namespace Pizza.API.Services.Interfaces
{
    public interface IFileService
    {
        Task<Guid> UploadFile(Stream stream, string contentType, CancellationToken cancellationToken = default);

        Task<FileResponse> Download(Guid fileId, CancellationToken cancellationToken = default);

        Task Delete(Guid fileId, CancellationToken cancellationToken = default);
    }
}
