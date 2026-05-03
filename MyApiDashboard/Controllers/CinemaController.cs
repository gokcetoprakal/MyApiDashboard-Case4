using Microsoft.AspNetCore.Mvc;

namespace MyApiDashboard.Controllers
{
    public class CinemaController : Controller
    {
        public IActionResult GetRandomMovieComponent()
        {
            return ViewComponent("_DefaultCinemaStream");
        }
    }
}
