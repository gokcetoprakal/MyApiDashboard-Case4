using Microsoft.AspNetCore.Mvc;

namespace MyApiDashboard.Controllers
{
    public class LinksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
