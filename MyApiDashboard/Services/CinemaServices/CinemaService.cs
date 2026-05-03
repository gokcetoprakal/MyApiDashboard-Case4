using MyApiDashboard.Dtos;
using System.Text.Json;

namespace MyApiDashboard.Services.CinemaServices
{
    public class CinemaService : ICinemaService
    {
        private readonly HttpClient _client;

        public CinemaService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CinemaDto> GetRandomMovieAsync()
        {
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "https://tmdb-movies-and-tv-shows-api-by-apirobots.p.rapidapi.com/v1/tmdb/random"
            );

            request.Headers.Add("X-RapidAPI-Key", "e57248e08dmsh3e7425c5c292a26p1c1895jsn9218e10df0bf");
            request.Headers.Add("X-RapidAPI-Host", "tmdb-movies-and-tv-shows-api-by-apirobots.p.rapidapi.com");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            return new CinemaDto
            {
                Title = root.TryGetProperty("title", out var t) ? t.GetString() : "No Title",
                // ImageUrl yerine JSON'daki 'overview' (açıklama) bilgisini alıyoruz
                Description = root.TryGetProperty("overview", out var o) ? o.GetString() : "No description available."
            };
        }
    }
}
