using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using StoreOperation.WebApi.Common.Api;
using StoreOperation.WebApi.Configuration.Context;

namespace StoreOperation.WebApi.Utilities.File.Local
{
    public class LocalFileService : IFileService
    {
        private readonly IStoreOperationConfigurationContext checkListConfigurationContext;
        private readonly IWebHostEnvironment _env;
        private readonly string[] validImageMimeTypes;


        public LocalFileService(IStoreOperationConfigurationContext checkListConfigurationContext,
            IWebHostEnvironment env)
        {
            this.checkListConfigurationContext = checkListConfigurationContext;
            _env = env;
            validImageMimeTypes = new[] {"image/jpeg", "image/png", "image/gif"};
        }

        public async Task<FileResult> InsertProfileImageAsync(IFormFile profileImageFile)
        {
            if (profileImageFile == null || profileImageFile.Length == 0)
            {
                return new FileResult(isSuccess: false, errorMessage: ResultMessage.ProfileImageCanNotBeNullOrEmpty,
                    newFileName: default, relativeFilePath: default);
            }

            //Check image max file length.
            if (profileImageFile.Length > this.checkListConfigurationContext.ProfileImageMaxFileLength)
            {
                return new FileResult(isSuccess: false, errorMessage: ResultMessage.InvalidProfileImageSize,
                    newFileName: default, relativeFilePath: default);
            }

            // Check image has valid extension?
            if (validImageMimeTypes.Contains(profileImageFile.ContentType.ToLower()) == false)
            {
                return new FileResult(isSuccess: false, errorMessage: ResultMessage.InvalidProfileImage,
                    newFileName: default, relativeFilePath: default);
            }

            // Generate unique name for file name.
            var fileName = Guid.NewGuid();

            var fileExtension = Path.GetExtension(profileImageFile.FileName);

            // File full name.
            var fileNameWithExtension = fileName + fileExtension;

            // Relative file path from main project files.
            var relativeFilePath = checkListConfigurationContext.ProfileImagePath + fileNameWithExtension;

            await using var stream = new FileStream(relativeFilePath, FileMode.Create);

            await profileImageFile.CopyToAsync(stream);

            return new FileResult(isSuccess: true, errorMessage: default, newFileName: fileNameWithExtension,
                relativeFilePath: relativeFilePath);
        }

        public async Task<ReadImageResult> ReadProfileImageAsync(string imgPath)
        {
            var path = Path.Combine(_env.ContentRootPath, imgPath);
            byte[] file = null;

            if (System.IO.File.Exists(path))
            {
                var provider = new FileExtensionContentTypeProvider();
                string contentType;
                if (!provider.TryGetContentType(path, out contentType))
                {
                    contentType = "image/jpeg";
                }

                file = await System.IO.File.ReadAllBytesAsync(path);
                return new ReadImageResult(contentType, file);
            }

            return new ReadImageResult("Resim dosyası bulunamadı.");
        }
    }
}