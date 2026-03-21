namespace CoAntiCor.Core.Services
{
    public interface IAttachmentService
    {
        /// <summary>
        /// Saves a file temporarily (before complaint submission).
        /// Returns a temporary storage path or ID.
        /// </summary>
        Task<string> SaveTempAsync(Stream fileStream, string fileName, string contentType);

        /// <summary>
        /// Moves a file from temporary storage to permanent complaint storage.
        /// Returns the final storage path.
        /// </summary>
        Task<string> MoveFromTempAsync(string tempPath);

        /// <summary>
        /// Deletes a temporary file.
        /// </summary>
        Task DeleteTempAsync(string tempPath);

        /// <summary>
        /// Deletes a permanently stored attachment.
        /// </summary>
        Task DeletePermanentAsync(string storagePath);

        /// <summary>
        /// Validates file type, size, and safety.
        /// Throws exceptions if invalid.
        /// </summary>
        void ValidateAttachment(string fileName, string contentType, long size);
    }
}