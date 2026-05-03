using MyApiDashboard.Dtos;
using System.Text.Json;

namespace MyApiDashboard.Services.LiveMatchServices
{
    public class LiveMatchService : ILiveMatchService
    {
        private readonly HttpClient _client;

        public LiveMatchService(HttpClient client)
        {
            _client = client;
        }

        public async Task<LiveMatchDto> GetLiveMatchAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://free-api-live-football-data.p.rapidapi.com/football-current-live"),
                Headers =
                {
                    { "X-RapidAPI-Key", "e57248e08dmsh3e7425c5c292a26p1c1895jsn9218e10df0bf" },
                    { "X-RapidAPI-Host", "free-api-live-football-data.p.rapidapi.com" },
                },
            };

            try
            {
                using (var response = await _client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var json = await response.Content.ReadAsStringAsync();

                    using var doc = JsonDocument.Parse(json);

                    // API genellikle { "status": "success", "data": [ ... ] } yapısında döner
                    if (doc.RootElement.TryGetProperty("data", out var dataElement) && dataElement.GetArrayLength() > 0)
                    {
                        // Listedeki ilk canlı maçı alıyoruz
                        var firstMatch = dataElement[0];

                        // Skor genelde "2-1" formatında gelir, güvenli bir şekilde parçalıyoruz
                        var scoreString = firstMatch.GetProperty("score").GetString() ?? "0-0";
                        var scoreParts = scoreString.Split('-');

                        return new LiveMatchDto
                        {
                            HomeTeam = firstMatch.GetProperty("home_name").GetString(),
                            AwayTeam = firstMatch.GetProperty("away_name").GetString(),
                            HomeScore = scoreParts.Length > 0 && int.TryParse(scoreParts[0], out int h) ? h : 0,
                            AwayScore = scoreParts.Length > 1 && int.TryParse(scoreParts[1], out int a) ? a : 0
                        };
                    }

                    // Eğer canlı maç yoksa boş dönmesin, kullanıcıya bilgi versin
                    return new LiveMatchDto
                    {
                        HomeTeam = "No Live",
                        AwayTeam = "Match",
                        HomeScore = 0,
                        AwayScore = 0
                    };
                }
            }
            catch (Exception)
            {
                // Hata durumunda loglama yapabilir veya varsayılan boş model dönebilirsin
                return new LiveMatchDto { HomeTeam = "Service", AwayTeam = "Error", HomeScore = 0, AwayScore = 0 };
            }
        }
    }
}
