using GambaNet_Web.Application.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GambaNet_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    public class ImageUploadController : Controller
    {
        private readonly IFileUploadService _fileUploadService;
        private readonly ILogger<ImageUploadController> _logger;

        public ImageUploadController(IFileUploadService fileUploadService, ILogger<ImageUploadController> logger)
        {
            _fileUploadService = fileUploadService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile image, string fileName, string folderName)
        {
            if (image == null)
            {
                ViewBag.ErrorMessage = "No file provided for upload.";
                _logger.LogWarning("No file provided for upload.");
                return View("Index");
            }

            try
            {
                string imagePath = _fileUploadService.FileUpload(image, folderName);
                ViewBag.UploadResult = imagePath;
                _logger.LogInformation($"File uploaded successfully: {imagePath}");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred while uploading the file: {ex.Message}";
                _logger.LogError(ex, "An error occurred while uploading the file.");
            }

            return View("Index");
        }
    }
}
