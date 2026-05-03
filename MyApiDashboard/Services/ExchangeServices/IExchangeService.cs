using MyApiDashboard.Dtos;

namespace MyApiDashboard.Services.ExchangeServices
{
    public interface IExchangeService
    {
        Task<ExchangeDto> GetExchangeRateAsync();
    }
}
