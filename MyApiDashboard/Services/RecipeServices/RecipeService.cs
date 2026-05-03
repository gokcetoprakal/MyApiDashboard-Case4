using MyApiDashboard.Dtos;
using System.Text.Json;

namespace MyApiDashboard.Services.RecipeServices
{
    public class RecipeService : IRecipeService
    {
        public readonly HttpClient _client;

        public RecipeService(HttpClient client)
        {
            _client = client;
        }

        public async Task<RecipeDto> GetRandomRecipeAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=20"),
                Headers =
        {
            { "X-RapidAPI-Key", "e57248e08dmsh3e7425c5c292a26p1c1895jsn9218e10df0bf" },
            { "X-RapidAPI-Host", "tasty.p.rapidapi.com" },
        },
            };

            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var recipes = doc.RootElement.GetProperty("results");

                var randomIndex = new Random().Next(0, recipes.GetArrayLength());
                var randomRecipe = recipes[randomIndex];

                return new RecipeDto
                {
                    Title = randomRecipe.GetProperty("name").GetString(),
                    Description = randomRecipe.TryGetProperty("description", out var desc)
                                  ? desc.GetString()
                                  : "No description available for this recipe."
                };
            }
        }
    }
}
