using MyApiDashboard.Dtos;

namespace MyApiDashboard.Services.CinemaServices
{
    public interface ICinemaService
    {
        Task<CinemaDto> GetRandomMovieAsync();
    }
}
