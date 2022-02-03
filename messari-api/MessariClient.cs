
using messari_api.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace messari_api;

internal interface IMessariClient
{
    Task<MarketDataResponse> GetAssetMarketDataAsync(string asset);
}

internal class MessariClient : IMessariClient
{
    private const string _url = "https://data.messari.io";
    private readonly HttpClient _httpClient;

    public MessariClient()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(_url)
        };
    }

    public MessariClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<MarketDataResponse> GetAssetMarketDataAsync(string asset)
    {
        HttpRequestMessage httpRequestMessage = BuildRequestMessage($"api/v1/assets/{asset}/metrics/market-data?fields=market_data/price_usd,id,symbol,name,slug");

        try
        {
            var response = await _httpClient.SendAsync(httpRequestMessage);
            response.EnsureSuccessStatusCode();
            return await JsonSerializer.DeserializeAsync<MarketDataResponse>(await response.Content.ReadAsStreamAsync());
        }
        catch(Exception ex)
        {
            //TODO: Log Error
            return null;
        }
    }

    private HttpRequestMessage BuildRequestMessage(string endpoint)
    {
        Uri uri = new(_httpClient.BaseAddress, endpoint);
        HttpRequestMessage request = new(HttpMethod.Get, uri);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return request;
    }
}
