using Newtonsoft.Json;
using System.Collections.Generic;

namespace RightStakes.Challenge.Services.Crawler.Models
{
    public class CurrencyConvertionModel
    {
        [JsonProperty(PropertyName = "success")]
        public bool Sucess { get; set; }

        [JsonProperty(PropertyName = "terms")]
        public string Terms { get; set; }

        [JsonProperty(PropertyName = "privacy")]
        public string Privacy { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "quotes")]
        public Dictionary<string, decimal?> Quotes { get; set; }
    }
}
