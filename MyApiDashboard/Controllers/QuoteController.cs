using Microsoft.AspNetCore.Mvc;

namespace MyApiDashboard.Controllers
{
    public class QuoteController : Controller
    {
        public IActionResult GetRandomQuoteComponent()
        {
            return ViewComponent("_DefaultWisdomPrompt");
        }
    }
}
