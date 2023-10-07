using CoinAPI.REST.V1;
using crypto_cli.Logging;
using crypto_cli.Options;
using messari_api;
using messari_api.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace crypto_cli.Runners
{
    public class GetRunner 
    {
        private static readonly ILogger _logger = SharedLogger.CreateLogger(nameof(GetRunner));
        private static readonly CoinApiRestClient _client;

        static GetRunner() => _client = new CoinApiRestClient("D1F1DA64-5FE3-4B35-89BE-FA7ED47C5A55");

        public static async Task<int> RunGetAndReturnExitCode(GetCommand opts)
        {
            if (IsCommandNotValid(opts))
                return 0;

            var result = await _client.Exchange_rates_get_specific_rateAsync(opts.Coin.ToUpperInvariant(), "USD");

            if (result is null)
            {
                Console.WriteLine($"No coin found mathching: {opts.Coin}");
            }
            else if (opts.Price)
            {
                //Console.WriteLine($"{result.Data.Symbol}: {result.Data.MarketData.PriceUsd:c}");
            }
            else
            {
                Console.WriteLine(JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true }));
            }

            return 1;
        }


        public static bool IsCommandNotValid(GetCommand opts)
        {
            if (opts is null)
            {
                throw new ArgumentNullException(nameof(opts));
            }

            if (opts.Coin is null)
            {
                _logger.LogInformation("{Coin} is required", nameof(opts.Coin));
                return true;
            }
            return false;
        }
    }
}
