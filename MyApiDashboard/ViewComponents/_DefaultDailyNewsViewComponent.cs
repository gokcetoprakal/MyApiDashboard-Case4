using Microsoft.AspNetCore.Mvc;
using MyApiDashboard.Services.NewsServices;
using System.Threading.Tasks;

namespace MyApiDashboard.ViewComponents
{
    public class _DefaultDailyNewsViewComponent : ViewComponent
    {
        public readonly INewsService _newsService;

        public _DefaultDailyNewsViewComponent(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var news = await _newsService.GetLastThreeNewsAsync();
            return View(news);
        }
    }
}
