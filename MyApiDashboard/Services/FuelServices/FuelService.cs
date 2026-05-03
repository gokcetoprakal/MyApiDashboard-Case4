using MyApiDashboard.Dtos;
using System.Text.Json;

namespace MyApiDashboard.Services.FuelServices
{
    public class FuelService : IFuelService
    {
        public readonly HttpClient _client;

        public FuelService(HttpClient client)
        {
            _client = client;
        }

        public async Task<FuelDto> GetFuelPricesAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://uk-daily-fuel-prices.p.rapidapi.com/fuel-prices"),
                Headers =
        {
            { "X-RapidAPI-Key", "e57248e08dmsh3e7425c5c292a26p1c1895jsn9218e10df0bf" },
            { "X-RapidAPI-Host", "uk-daily-fuel-prices.p.rapidapi.com" },
        },
            };

            try
            {
                using (var response = await _client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var json = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(json);
                    var root = doc.RootElement;

                    return new FuelDto
                    {
                        Benzin = root.GetProperty("unleaded").GetDecimal(),
                        Motorin = root.GetProperty("diesel").GetDecimal(),
                        Lpg = root.TryGetProperty("lpg", out var l) ? l.GetDecimal() : 22.10m
                    };
                }
            }
            catch
            {
                // Hata durumunda Dashboard'un boş kalmaması için sabit veriler
                return new FuelDto { Benzin = 42.15m, Motorin = 43.20m, Lpg = 21.85m };
            }
        }
    }
}
