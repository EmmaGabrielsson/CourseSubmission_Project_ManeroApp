using Manero.Models.Interfaces;

namespace Manero.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _hostEnvironment;

    public FileService(IWebHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }
    public async Task<string> SaveFileAsync(IFormFile file, string directoryPath)
    {
        var fileName = Path.GetFileNameWithoutExtension(file.FileName);
        var extension = Path.GetExtension(file.FileName);
        var fileNewName = $"{Guid.NewGuid()}_{DateTime.Now:yyyyMMddHHmmss}{fileName}{extension}";

        var filePath = Path.Combine(_hostEnvironment.WebRootPath, directoryPath, fileNewName).Replace("\\", "/");

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return "/" + Path.Combine(directoryPath, fileNewName);
    }
    public void DeleteFile(string fullFilePath)
    {
        if (System.IO.File.Exists(fullFilePath))
        {
            System.IO.File.Delete(fullFilePath);
        }
    }
}
