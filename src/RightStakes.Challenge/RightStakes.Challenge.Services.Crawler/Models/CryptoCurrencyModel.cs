using Newtonsoft.Json;
using System;

namespace RightStakes.Challenge.Services.Crawler.Models
{
    public class CryptoCurrencyModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "current_price")]
        public decimal CurrentPrice { get; set; }

        [JsonProperty(PropertyName = "market_cap")]
        public long MarketCap { get; set; }

        [JsonProperty(PropertyName = "market_cap_rank")]
        public int MarketCapRank { get; set; }

        [JsonProperty(PropertyName = "fully_diluted_valuation")]
        public long FullyDilutedValuation { get; set; }

        [JsonProperty(PropertyName = "total_volume")]
        public long TotalVolume { get; set; }

        [JsonProperty(PropertyName = "high_24h")]
        public decimal? High24h { get; set; }

        [JsonProperty(PropertyName = "low_24h")]
        public decimal? Low24h { get; set; }

        [JsonProperty(PropertyName = "price_change_24h")]
        public decimal? PriceChange24h { get; set; }

        [JsonProperty(PropertyName = "price_change_percentage_24h")]
        public decimal? PriceChangePercentage24h { get; set; }

        [JsonProperty(PropertyName = "market_cap_change_24h")]
        public decimal? MarketCapChange24h { get; set; }

        [JsonProperty(PropertyName = "market_cap_change_percentage_24h")]
        public decimal? MarketCapChangePercentage24h { get; set; }

        [JsonProperty(PropertyName = "circulating_supply")]
        public decimal? CirculatingSupply { get; set; }

        [JsonProperty(PropertyName = "total_supply")]
        public decimal? TotalSupply { get; set; }

        [JsonProperty(PropertyName = "max_supply")]
        public decimal? MaxSupply { get; set; }

        [JsonProperty(PropertyName = "ath")]
        public decimal? Ath { get; set; }

        [JsonProperty(PropertyName = "ath_change_percentage")]
        public decimal? AthChangePercentage { get; set; }

        [JsonProperty(PropertyName = "ath_date")]
        public DateTime? AthDate { get; set; }

        [JsonProperty(PropertyName = "atl")]
        public decimal? Atl { get; set; }

        [JsonProperty(PropertyName = "atl_change_percentage")]
        public decimal? AtlChangePercentage { get; set; }

        [JsonProperty(PropertyName = "atl_date")]
        public DateTime? AtlDate { get; set; }
    }
}
