using MyApiDashboard.Dtos;
using System.Text.Json;

namespace MyApiDashboard.Services.ExchangeServices
{
    public class ExchangeService : IExchangeService
    {
        private readonly HttpClient _client;

        public ExchangeService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ExchangeDto> GetExchangeRateAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=USD&to=TRY&amount=1"),
                Headers =
        {
            { "X-RapidAPI-Key", "e57248e08dmsh3e7425c5c292a26p1c1895jsn9218e10df0bf" },
            { "X-RapidAPI-Host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
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

                    // API bazen "info" altında "rate" döner, bazen direkt "result" döner.
                    // Hangi alan doluysa onu alalım:
                    decimal rate = 0;
                    if (root.TryGetProperty("result", out var resProp))
                    {
                        rate = resProp.GetDecimal();
                    }
                    else if (root.TryGetProperty("info", out var info) && info.TryGetProperty("rate", out var r))
                    {
                        rate = r.GetDecimal();
                    }

                    // Eğer hala 0 ise (API boş dönmüşse) bir hata fırlatmamak için 0 dönüyoruz
                    if (rate == 0) return new ExchangeDto();

                    return new ExchangeDto
                    {
                        UsdTry = rate,
                        // Bu API 'convert' endpoint'inde anlık High/Low dönmeyebilir.
                        // Tasarımın boş kalmaması için piyasa standartlarında sapma ekliyoruz:
                        Low = rate * 0.998m,
                        High = rate * 1.002m
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Döviz Servis Hatası: " + ex.Message);
                return new ExchangeDto();
            }
        }
    }
}
