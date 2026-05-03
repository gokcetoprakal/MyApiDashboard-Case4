using MyApiDashboard.Dtos;

namespace MyApiDashboard.Services.LiveMatchServices
{
    public interface ILiveMatchService
    {
        Task<LiveMatchDto> GetLiveMatchAsync();
    }
}
