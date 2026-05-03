using MyApiDashboard.Dtos;
using System.Text.Json;

namespace MyApiDashboard.Services.QuoteServices
{
    public class QuoteService : IQuoteService
    {
        private readonly HttpClient _client;

        public QuoteService(HttpClient client)
        {
            _client = client;
        }

        public async Task<QuoteDto> GetRandomQuoteAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                // Rastgele tek bir söz almak için endpoint'i kontrol et
                RequestUri = new Uri("https://quotes-api12.p.rapidapi.com/quotes"),
                Headers =
        {
            { "X-RapidAPI-Key", "e57248e08dmsh3e7425c5c292a26p1c1895jsn9218e10df0bf" },
            { "X-RapidAPI-Host", "quotes-api12.p.rapidapi.com" },
        },
            };

            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                // EĞER API direkt objeyi dönüyorsa [0] kullanmamalıyız:
                return new QuoteDto
                {
                    // Bu API genellikle 'quote' veya 'content' ismini kullanır, 
                    // 'text' gelmezse 'quote' olarak değiştirmeyi dene
                    Text = root.TryGetProperty("quote", out var q) ? q.GetString() : root.GetProperty("content").GetString(),
                    Author = root.GetProperty("author").GetString()
                };
            }
        }
    }
}
