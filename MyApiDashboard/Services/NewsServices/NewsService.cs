using MyApiDashboard.Dtos;
using System.Text.Json;

namespace MyApiDashboard.Services.NewsServices
{
    public class NewsService : INewsService
    {
        private readonly HttpClient _client;

        public NewsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<NewsDto>> GetLastThreeNewsAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-news-data.p.rapidapi.com/top-headlines?limit=3&country=US&lang=en"),
                Headers =
                {
                    { "X-RapidAPI-Key", "e57248e08dmsh3e7425c5c292a26p1c1895jsn9218e10df0bf" },
                    { "X-RapidAPI-Host", "real-time-news-data.p.rapidapi.com" },
                },
            };

            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);

                var newsList = new List<NewsDto>();
                var data = doc.RootElement.GetProperty("data");

                // Sadece ilk 3 haberi alıyoruz
                for (int i = 0; i < Math.Min(3, data.GetArrayLength()); i++)
                {
                    var item = data[i];
                    newsList.Add(new NewsDto
                    {
                        Title = item.GetProperty("title").GetString(),
                        Url = item.GetProperty("link").GetString()
                    });
                }
                return newsList;
            }
        }
    }
}
