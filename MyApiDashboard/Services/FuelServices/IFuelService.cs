using MyApiDashboard.Dtos;

namespace MyApiDashboard.Services.FuelServices
{
    public interface IFuelService
    {
        Task<FuelDto> GetFuelPricesAsync();
    }
}
