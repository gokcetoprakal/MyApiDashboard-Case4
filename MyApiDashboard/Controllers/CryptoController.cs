using Microsoft.AspNetCore.Mvc;

namespace MyApiDashboard.Controllers
{
    public class CryptoController : Controller
    {
        public IActionResult GetCryptoPricesComponent()
        {
            return ViewComponent("_DefaultCryptoMiner");
        }
    }
}
