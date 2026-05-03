using Microsoft.AspNetCore.Mvc;

namespace MyApiDashboard.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
