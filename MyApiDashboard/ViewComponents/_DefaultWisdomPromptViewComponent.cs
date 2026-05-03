using Microsoft.AspNetCore.Mvc;
using MyApiDashboard.Services.QuoteServices;

namespace MyApiDashboard.ViewComponents
{
    public class _DefaultWisdomPromptViewComponent : ViewComponent
    {
        public readonly IQuoteService _quoteService;

        public _DefaultWisdomPromptViewComponent(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var quote = await _quoteService.GetRandomQuoteAsync();
            return View(quote);
        }
    }
}
