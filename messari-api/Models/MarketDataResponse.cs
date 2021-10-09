using System.Text.Json.Serialization;

namespace messari_api.Models
{
    public partial class MarketDataResponse
    {
        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("market_data")]
        public MarketData MarketData { get; set; }
    }

    public partial class MarketData
    {
        [JsonPropertyName("price_usd")]
        public double PriceUsd { get; set; }

        [JsonPropertyName("volume_last_24_hours")]
        public double VolumeLast24_Hours { get; set; }

        [JsonPropertyName("real_volume_last_24_hours")]
        public double RealVolumeLast24_Hours { get; set; }
    }

    public partial class Status
    {
        [JsonPropertyName("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonPropertyName("elapsed")]
        public long Elapsed { get; set; }
    }
}