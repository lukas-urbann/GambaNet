using GambaNet_Web.Application.Abstraction;
using Microsoft.AspNetCore.Http;

public class ThumbnailUploadService : IThumbnailUploadService
{
    private readonly string _uploadPath;

    public ThumbnailUploadService(string uploadPath)
    {
        _uploadPath = uploadPath;
    }

    public string FileUpload(IFormFile fileToUpload, string folderNameOnServer)
    {
        if (fileToUpload == null || fileToUpload.Length == 0)
        {
            throw new ArgumentException("No file provided for upload.");
        }

        var uploadFolder = Path.Combine(_uploadPath, folderNameOnServer);
        if (!Directory.Exists(uploadFolder))
        {
            Directory.CreateDirectory(uploadFolder);
        }

        var fileName = Path.GetFileName(fileToUpload.FileName);
        var filePath = Path.Combine(uploadFolder, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            fileToUpload.CopyTo(fileStream);
        }

        return Path.Combine(folderNameOnServer, fileName);
    }

    
}
