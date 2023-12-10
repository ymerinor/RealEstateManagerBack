using Microsoft.AspNetCore.Http;

namespace RealEstateManager.Domain.FilesManager
{
    public interface IFilesManager
    {
        Task<string> SaveImageAsync(IFormFile imageDto);
    }
}
