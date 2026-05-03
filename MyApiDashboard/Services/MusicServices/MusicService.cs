using MyApiDashboard.Dtos;
using System.Text.Json;

namespace MyApiDashboard.Services.MusicServices
{
    public class MusicService : IMusicService
    {
        private readonly HttpClient _client;
        private static readonly Random _random = new();

        public MusicService(HttpClient client)
        {
            _client = client;
        }

        public async Task<MusicDto> GetDailyMusicAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://spotify81.p.rapidapi.com/browse/new-releases?limit=10&offset=0"),
                Headers =
                {
                    { "X-RapidAPI-Key", "e57248e08dmsh3e7425c5c292a26p1c1895jsn9218e10df0bf" },
                    { "X-RapidAPI-Host", "spotify81.p.rapidapi.com" },
                },
            };

            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(json);

                var items = doc.RootElement
                               .GetProperty("albums")
                               .GetProperty("items");

                int index = _random.Next(items.GetArrayLength());
                var selectedAlbum = items[index];

                return new MusicDto
                {
                    Song = selectedAlbum.GetProperty("name").GetString(),

                    Artist = selectedAlbum.GetProperty("artists")[0]
                                          .GetProperty("name").GetString()
                };
            }
        }
    }
}
