using MyApiDashboard.Dtos;

namespace MyApiDashboard.Services.MusicServices
{
    public interface IMusicService
    {
        Task<MusicDto> GetDailyMusicAsync();
    }
}
