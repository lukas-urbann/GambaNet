using GambaNet_Web.Application.Abstraction;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace GambaNet_Web.Application.Implementation
{
    public class FileUploadService : IFileUploadService
    {
        public string RootPath { get; set; }

        public FileUploadService(string rootPath)
        {
            this.RootPath = rootPath;
        }

        public string FileUpload(IFormFile fileToUpload, string folderNameOnServer)
        {
            string filePathOutput = string.Empty;
            var fileName = Path.GetFileNameWithoutExtension(fileToUpload.FileName);
            var fileExtension = Path.GetExtension(fileToUpload.FileName);
            var fileRelative = Path.Combine(folderNameOnServer, fileName + fileExtension);
            var filePath = Path.Combine(this.RootPath, fileRelative);
            Directory.CreateDirectory(Path.Combine(this.RootPath, folderNameOnServer));
            using (Stream stream = new FileStream(filePath, FileMode.Create))
            {
                fileToUpload.CopyTo(stream);
            }
            filePathOutput = Path.DirectorySeparatorChar + fileRelative;
            return filePathOutput;
        }
    }
}

