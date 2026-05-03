using Microsoft.AspNetCore.Mvc;
using MyApiDashboard.Services.WeatherServices;

namespace MyApiDashboard.ViewComponents
{
    public class _DefaultWeatherViewComponent : ViewComponent
    {
        public readonly IWeatherService _weatherService;

        public _DefaultWeatherViewComponent(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var weather = await _weatherService.GetRandomCityWeatherAsync();
            return View(weather);
        }
    }
}
