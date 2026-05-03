using Microsoft.AspNetCore.Mvc;
using MyApiDashboard.Services.LiveMatchServices;
using System.Threading.Tasks;

namespace MyApiDashboard.ViewComponents
{
    public class _DefaultLiveScoresViewComponent : ViewComponent
    {
        public ILiveMatchService _liveMatchService;

        public _DefaultLiveScoresViewComponent(ILiveMatchService liveMatchService)
        {
            _liveMatchService = liveMatchService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var match = await _liveMatchService.GetLiveMatchAsync();
            return View(match);
        }
    }
}
