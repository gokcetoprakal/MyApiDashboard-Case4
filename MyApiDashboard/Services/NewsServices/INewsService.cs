using MyApiDashboard.Dtos;

namespace MyApiDashboard.Services.NewsServices
{
    public interface INewsService
    {
        Task<List<NewsDto>> GetLastThreeNewsAsync();
    }
}
