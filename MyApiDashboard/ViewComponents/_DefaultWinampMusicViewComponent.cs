using Microsoft.AspNetCore.Mvc;
using MyApiDashboard.Services.MusicServices;

namespace MyApiDashboard.ViewComponents
{
    public class _DefaultWinampMusicViewComponent : ViewComponent
    {
        public readonly IMusicService _musicService;

        public _DefaultWinampMusicViewComponent(IMusicService musicService)
        {
            _musicService = musicService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var song = await _musicService.GetDailyMusicAsync();
            return View(song);
        }
    }
}
