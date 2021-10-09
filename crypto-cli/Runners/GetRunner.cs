using crypto_cli.Logging;
using crypto_cli.Options;
using messari_api;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace crypto_cli.Runners
{
    public static class GetRunner
    {
        private static readonly ILogger _logger = SharedLogger.CreateLogger(nameof(GetRunner));
        private static readonly MessariClient _messariClient;

        static GetRunner()
        {
            _messariClient = new MessariClient();
        }

        public static async Task<int> RunGetAndReturnExitCode(GetOptions opts)
        {
            if (opts is null)
            {
                throw new ArgumentNullException(nameof(opts));
            }

            if (opts.Coin is null)
            {
                throw new ArgumentNullException($"{nameof(opts.Coin) } cannot be null");
            }

            var result = await _messariClient.GetAssetMarketDataAsync(opts.Coin);

            if (result is null) 
            {
                Console.WriteLine($"No coin found mathching: {opts.Coin}");
            }
            else if (opts.Price)
            {
                Console.WriteLine($"{result.Data.Symbol}: {result.Data.MarketData.PriceUsd:c}");
            } 
            else
            {
                Console.WriteLine(JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true }));
            }

            return 1;
        }
    }
}
