using Microsoft.AspNetCore.Http;

namespace VehicleInspection.Framework.FileService
{
    public interface IFileService
    {
        public string Upload(IFormFile file, string folder);
    }
}