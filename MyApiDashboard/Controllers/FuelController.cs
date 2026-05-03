using Microsoft.AspNetCore.Mvc;

namespace MyApiDashboard.Controllers
{
    public class FuelController : Controller
    {
        public IActionResult GetAllFuelsComponent()
        {
            return ViewComponent("_DefaultFuelPrices");
        }
    }
}
