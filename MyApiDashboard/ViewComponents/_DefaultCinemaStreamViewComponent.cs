using Microsoft.AspNetCore.Mvc;
using MyApiDashboard.Services.CinemaServices;

namespace MyApiDashboard.ViewComponents
{
    public class _DefaultCinemaStreamViewComponent : ViewComponent
    {
        private readonly ICinemaService _cinemaService;

        public _DefaultCinemaStreamViewComponent(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var movie = await _cinemaService.GetRandomMovieAsync();
            return View(movie);
        }
    }
}
