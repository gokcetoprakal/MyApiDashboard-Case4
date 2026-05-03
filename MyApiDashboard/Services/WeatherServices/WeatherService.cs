using MyApiDashboard.Dtos;
using System.Text.Json;

namespace MyApiDashboard.Services.WeatherServices
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _client;
        // Rastgele seçilecek şehir havuzumuz
        private readonly string[] _cities = { "Istanbul", "London", "New York", "Tokyo", "Berlin", "Paris", "Rome", "Amsterdam" };
        private static readonly Random _random = new();

        public WeatherService(HttpClient client)
        {
            _client = client;
        }

        public async Task<WeatherDto> GetRandomCityWeatherAsync()
        {
            var randomCity = _cities[_random.Next(_cities.Length)];

            // Senin belirttiğin Query Param (?city=...) yapısına uygun URI
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://open-weather13.p.rapidapi.com/city?city={randomCity}&lang=EN"),
                Headers =
        {
            { "X-RapidAPI-Key", "e57248e08dmsh3e7425c5c292a26p1c1895jsn9218e10df0bf" },
            { "X-RapidAPI-Host", "open-weather13.p.rapidapi.com" },
        },
            };

            using (var response = await _client.SendAsync(request))
            {
                // Eğer 404 veya 400 alırsan burası hata fırlatır, böylece sorunu anlarız
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                // Sıcaklık dönüşümü (Fahrenheit to Celsius)
                double fahrenheit = root.GetProperty("main").GetProperty("temp").GetDouble();
                double celsius = (fahrenheit - 32) / 1.8;

                return new WeatherDto
                {
                    City = root.GetProperty("name").GetString(),
                    Temperature = (int)Math.Round(celsius)
                };
            }
        }
    }
}
