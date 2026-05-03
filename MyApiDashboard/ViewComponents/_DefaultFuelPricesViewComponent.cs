using Microsoft.AspNetCore.Mvc;
using MyApiDashboard.Services.FuelServices;

namespace MyApiDashboard.ViewComponents
{
    public class _DefaultFuelPricesViewComponent : ViewComponent
    {
        public readonly IFuelService _fuelService;

        public _DefaultFuelPricesViewComponent(IFuelService fuelService)
        {
            _fuelService = fuelService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var fuelPrices = await _fuelService.GetFuelPricesAsync();
            return View(fuelPrices);
        }
    }
}
