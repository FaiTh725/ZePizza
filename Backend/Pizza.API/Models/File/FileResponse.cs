namespace Pizza.API.Models.File
{
    public class FileResponse
    {
        public Stream Stream { get; set; } = new MemoryStream();

        public string ContentType { get; set; } = string.Empty;
    }
}
