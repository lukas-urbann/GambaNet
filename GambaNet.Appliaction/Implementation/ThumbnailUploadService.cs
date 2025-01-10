using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GambaNet_Web.Application.Abstraction;
using Microsoft.AspNetCore.Http;

namespace GambaNet_Web.Application.Implementation
{
    public class ThumbnailUploadService : IThumbnailUploadService
    {
        public string Path { get; set; }

        public ThumbnailUploadService(string path)
        {
            this.Path = path;
        }

        public string FileUpload(IFormFile fileToUpload, string folderNameOnServer)
        {
            string path = Path + folderNameOnServer;
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string fileName = Guid.NewGuid().ToString() + fileToUpload.FileName;
            string fullPath = path + "/" + fileName;
            using (var stream = System.IO.File.Create(fullPath))
            {
                fileToUpload.CopyTo(stream);
            }
            return fileName;
        }
    }
}
