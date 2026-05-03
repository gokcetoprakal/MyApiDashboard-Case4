using MyApiDashboard.Dtos;

namespace MyApiDashboard.Services.QuoteServices
{
    public interface IQuoteService
    {
        Task<QuoteDto> GetRandomQuoteAsync();
    }
}
