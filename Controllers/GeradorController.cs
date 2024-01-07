using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace GeradorDeQrCode.Controllers
{
    public class GeradorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateQrCode()
        {
            var produtoNome = "Arroz";
            using(MemoryStream stream = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrData = qrGenerator.CreateQrCode(produtoNome, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrData);

                using(Bitmap codeBitmap = qrCode.GetGraphic(20))
                {
                    codeBitmap.Save(stream, ImageFormat.Png);
                    ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(stream.ToArray());
                }
            }
            return View();
        }
    }
}
