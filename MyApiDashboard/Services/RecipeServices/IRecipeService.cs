using MyApiDashboard.Dtos;

namespace MyApiDashboard.Services.RecipeServices
{
    public interface IRecipeService
    {
        Task<RecipeDto> GetRandomRecipeAsync();
    }
}
