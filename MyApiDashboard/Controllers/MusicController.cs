using Microsoft.AspNetCore.Mvc;

namespace MyApiDashboard.Controllers
{
    public class MusicController : Controller
    {
        public IActionResult GetDailyMusicComponent()
        {
            return ViewComponent("_DefaultWinampMusic");
        }
    }
}
