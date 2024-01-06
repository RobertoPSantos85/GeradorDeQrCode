using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
    }
}
