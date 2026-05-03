using Microsoft.AspNetCore.Mvc;
using MyApiDashboard.Services.ExchangeServices;

namespace MyApiDashboard.ViewComponents
{
    public class _DefaultExchangeRatesViewComponent : ViewComponent
    {
        public readonly IExchangeService _exchangeService;

        public _DefaultExchangeRatesViewComponent(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var exchangeRates = await _exchangeService.GetExchangeRateAsync();
            return View(exchangeRates);
        }
    }
}
