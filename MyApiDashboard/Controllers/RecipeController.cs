using Microsoft.AspNetCore.Mvc;

namespace MyApiDashboard.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult GetRandomRecipeComponent()
        {
            return ViewComponent("_DefaultKitchenRecipe");
        }
    }
}
