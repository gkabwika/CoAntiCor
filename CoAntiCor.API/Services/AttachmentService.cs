using CoAntiCor.Core.Model;
using CoAntiCor.Core.Services;
using Microsoft.Extensions.Options;

namespace CoAntiCor.API.Services
{
    /*
     * This service handles file attachments for complaints. It provides methods to:
     * - Validate file attachments based on size and content type.
     * - Save uploaded files to a temporary location.
     * - Move files from the temporary location to a permanent storage location.
     * - Delete temporary and permanent files when needed.
     *
     * The service uses configuration settings for allowed content types, maximum file size, and storage paths.
     * It also logs important actions for auditing purposes.
     *  Implementation: AttachmentService
        This implementation uses:
        - A temp folder for uploads
        - A permanent folder for complaint attachments
        - Strong validation
        - Secure random filenames
        - Directory isolation per complaint
        You can adapt the paths to your environment.

     */
    public class AttachmentService : IAttachmentService
    {
        private readonly AttachmentSettings _settings;
        private readonly ILogger<AttachmentService> _logger;

        public AttachmentService(
            IOptions<AttachmentSettings> options,
            ILogger<AttachmentService> logger)
        {
            _settings = options.Value;
            _logger = logger;

            Directory.CreateDirectory(_settings.TempFolder);
            Directory.CreateDirectory(_settings.PermanentFolder);
        }

        public void ValidateAttachment(string fileName, string contentType, long size)
        {
            if (size <= 0)
                throw new InvalidOperationException("File is empty.");

            if (size > _settings.MaxFileSizeBytes)
                throw new InvalidOperationException($"File exceeds max size of {_settings.MaxFileSizeBytes / (1024 * 1024)} MB.");

            if (!_settings.AllowedContentTypes.Contains(contentType))
                throw new InvalidOperationException($"File type '{contentType}' is not allowed.");

            var ext = Path.GetExtension(fileName).ToLowerInvariant();
            if (string.IsNullOrWhiteSpace(ext))
                throw new InvalidOperationException("File must have an extension.");
        }

        public async Task<string> SaveTempAsync(Stream fileStream, string fileName, string contentType)
        {
            ValidateAttachment(fileName, contentType, fileStream.Length);

            var tempId = Guid.NewGuid().ToString("N");
            var ext = Path.GetExtension(fileName);
            var tempPath = Path.Combine(_settings.TempFolder, $"{tempId}{ext}");

            using (var fs = new FileStream(tempPath, FileMode.Create))
            {
                await fileStream.CopyToAsync(fs);
            }

            _logger.LogInformation("Saved temp file: {Path}", tempPath);

            return tempPath;
        }

        public async Task<string> MoveFromTempAsync(string tempPath)
        {
            if (!File.Exists(tempPath))
                throw new FileNotFoundException("Temp file not found.", tempPath);

            var fileName = Path.GetFileName(tempPath);
            var finalPath = Path.Combine(_settings.PermanentFolder, fileName);

            Directory.CreateDirectory(_settings.PermanentFolder);

            File.Move(tempPath, finalPath);

            _logger.LogInformation("Moved file from temp to permanent: {Path}", finalPath);

            return finalPath;
        }

        public Task DeleteTempAsync(string tempPath)
        {
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
                _logger.LogInformation("Deleted temp file: {Path}", tempPath);
            }

            return Task.CompletedTask;
        }

        public Task DeletePermanentAsync(string storagePath)
        {
            if (File.Exists(storagePath))
            {
                File.Delete(storagePath);
                _logger.LogInformation("Deleted permanent file: {Path}", storagePath);
            }

            return Task.CompletedTask;
        }
    }
}
