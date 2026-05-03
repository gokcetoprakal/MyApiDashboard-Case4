using Microsoft.AspNetCore.Mvc;
using MyApiDashboard.Services.RecipeServices;

namespace MyApiDashboard.ViewComponents
{
    public class _DefaultKitchenRecipeViewComponent : ViewComponent
    {
        public readonly IRecipeService _recipeService;

        public _DefaultKitchenRecipeViewComponent(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var recipe = await _recipeService.GetRandomRecipeAsync();
            return View(recipe);
        }
    }
}
