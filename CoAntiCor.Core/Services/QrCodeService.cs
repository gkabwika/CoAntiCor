using CoAntiCor.Core.Interfaces;
using QRCoder;

namespace CoAntiCor.Core.Services
{
    /// <summary>
    /// This service generates a QR code as a byte array (PNG format) for the given content.
    /// </summary>
    public class QrCodeService : IQrCodeService
    {
        public byte[] GenerateQrCode(string content)
        {
            using var generator = new QRCodeGenerator();
            using var data = generator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);

            var png = new PngByteQRCode(data);
            return png.GetGraphic(20); // 20 = pixel size
        }
    }
}
