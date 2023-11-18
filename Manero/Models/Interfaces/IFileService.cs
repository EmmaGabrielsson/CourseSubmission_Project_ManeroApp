namespace Manero.Models.Interfaces;

public interface IFileService
{
    Task<string> SaveFileAsync(IFormFile file, string directoryPath);
    void DeleteFile(string filePath);
}
