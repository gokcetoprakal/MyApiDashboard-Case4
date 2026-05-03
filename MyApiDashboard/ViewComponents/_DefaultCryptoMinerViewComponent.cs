using Microsoft.AspNetCore.Mvc;
using MyApiDashboard.Services.CryptoServices;

namespace MyApiDashboard.ViewComponents
{
    public class _DefaultCryptoMinerViewComponent : ViewComponent
    {
        public readonly ICryptoService _cryptoService;

        public _DefaultCryptoMinerViewComponent(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cryptoPrices = await _cryptoService.GetCryptoPricesAsync();
            return View(cryptoPrices);
        }
    }
}
