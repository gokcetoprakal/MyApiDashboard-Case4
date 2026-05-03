using Microsoft.AspNetCore.Mvc;

namespace MyApiDashboard.Controllers
{
    public class LiveMatchController : Controller
    {
        public IActionResult GetLiveMatchComponent()
        {
            return ViewComponent("_DefaultLiveScores");
        }
    }
}
