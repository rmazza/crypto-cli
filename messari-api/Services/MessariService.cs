using messari_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messari_api.Services
{
    public interface IMessariService
    {
        Task<MarketDataResponse> GetAssetMarketDataAsync(string asset);
    }

    public class MessariService : IMessariService
    {
        private readonly IMessariClient _messariClient; 
        public MessariService()
        {
            _messariClient = new MessariClient();
        }

        public Task<MarketDataResponse> GetAssetMarketDataAsync(string asset) => _messariClient.GetAssetMarketDataAsync(asset);
    }
}
