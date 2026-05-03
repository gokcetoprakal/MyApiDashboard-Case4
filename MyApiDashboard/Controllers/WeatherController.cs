using Microsoft.AspNetCore.Mvc;

namespace MyApiDashboard.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult GetRandomCityWeatherComponent()
        {
            return ViewComponent("_DefaultWeather");
        }
    }
}
