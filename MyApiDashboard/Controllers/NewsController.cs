using Microsoft.AspNetCore.Mvc;

namespace MyApiDashboard.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult GetLastThreeNewsComponent()
        {
            return ViewComponent("_DefaultDailyNews");
        }
    }
}
