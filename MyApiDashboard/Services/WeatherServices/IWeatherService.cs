using MyApiDashboard.Dtos;

namespace MyApiDashboard.Services.WeatherServices
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetRandomCityWeatherAsync();
    }
}
