using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace NBP.Application.Interfaces
{
    public interface IPhotoRepository
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

    }
}
