namespace CoAntiCor.API.Services
{
    public interface IComplaintNumberGenerator
    {
        /// <summary>
        /// Generates a new, unique complaint number.
        /// Format example: "2026-00001234"
        /// </summary>
        Task<string> GenerateAsync();
    }
}