using MyApiDashboard.Dtos;

namespace MyApiDashboard.Services.CryptoServices
{
    public interface ICryptoService
    {
        Task<CryptoDto> GetCryptoPricesAsync();
    }
}
