using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StoreOperation.WebApi.Utilities.File
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Insert image to file server.
        /// </summary>
        /// <param name="profileImageFile">Profile image file</param>
        /// <returns></returns>
        Task<FileResult> InsertProfileImageAsync(IFormFile profileImageFile);

        Task<ReadImageResult> ReadProfileImageAsync(string imgPath);
    }
}
