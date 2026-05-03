using Microsoft.AspNetCore.Mvc;

namespace MyApiDashboard.Controllers
{
    public class ExchangeController : Controller
    {
        public IActionResult GetExchangeRatesComponent()
        {
            return ViewComponent("_DefaultExchangeRates");
        }
    }
}
