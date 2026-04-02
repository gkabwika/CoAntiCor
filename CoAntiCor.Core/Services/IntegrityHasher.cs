
namespace CoAntiCor.Core.Services
{
    public static class IntegrityHasher
    {
        /// <summary>
        /// Hash helper
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ComputeSha256Hex(byte[] data)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var hash = sha.ComputeHash(data);
            return Convert.ToHexString(hash); // .NET 5+
        }
    }
}
