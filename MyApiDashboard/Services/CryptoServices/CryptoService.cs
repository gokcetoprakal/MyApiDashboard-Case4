using MyApiDashboard.Dtos;
using System.Text.Json;

namespace MyApiDashboard.Services.CryptoServices
{
    public class CryptoService : ICryptoService
    {
        private readonly HttpClient _client;

        public CryptoService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CryptoDto> GetCryptoPricesAsync()
        {
            try
            {
                // Doğrudan Coingecko Public API. Key veya Auth gerektirmez.
                var url = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin,ethereum,solana,ripple&vs_currencies=usd";

                // Bazı API'ler tarayıcı dışı isteklerde User-Agent bekleyebilir, eklemekte fayda var.
                _client.DefaultRequestHeaders.Add("User-Agent", "MyDashboardApp");

                var response = await _client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    // Rate limit (429) durumunda boş dönerek arayüzün çökmesini engelleriz
                    return new CryptoDto();
                }

                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                return new CryptoDto
                {
                    Btc = root.GetProperty("bitcoin").GetProperty("usd").GetDecimal(),
                    Eth = root.GetProperty("ethereum").GetProperty("usd").GetDecimal(),
                    Sol = root.GetProperty("solana").GetProperty("usd").GetDecimal(),
                    Xrp = root.GetProperty("ripple").GetProperty("usd").GetDecimal()
                };
            }
            catch
            {
                // İnternet kesintisi vb. durumlarda uygulamanın geri kalanı çalışmaya devam etsin
                return new CryptoDto();
            }
        }
    }
}
