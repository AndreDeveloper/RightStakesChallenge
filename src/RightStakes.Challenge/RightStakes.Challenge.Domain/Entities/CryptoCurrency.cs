using System;

namespace RightStakes.Challenge.Domain.Entities
{
    public class CryptoCurrency : Entity
    {
        public string Id { get; private set; }

        public string Symbol { get; private set; }

        public string Name { get; private set; }

        public string Image { get; private set; }

        public decimal CurrentPrice { get; private set; }

        public long MarketCap { get; private set; }

        public int MarketCapRank { get; private set; }

        public long FullyDilutedValuation { get; private set; }

        public long TotalVolume { get; private set; }

        public decimal? High24h { get; private set; }

        public decimal? Low24h { get; private set; }

        public decimal? PriceChange24h { get; private set; }

        public decimal? PriceChangePercentage24h { get; private set; }

        public decimal? MarketCapChange24h { get; private set; }

        public decimal? MarketCapChangePercentage24h { get; private set; }

        public decimal? CirculatingSupply { get; private set; }

        public decimal? TotalSupply { get; private set; }

        public decimal? MaxSupply { get; private set; }

        public decimal? Ath { get; private set; }

        public decimal? AthChangePercentage { get; private set; }

        public DateTime? AthDate { get; private set; }

        public decimal? Atl { get; private set; }

        public decimal? AtlChangePercentage { get; private set; }

        public DateTime? AtlDate { get; private set; }

        public string Currency { get; private set; }

        protected CryptoCurrency() { }

        public CryptoCurrency(
            string id,
            string symbol,
            string name,
            string image,
            decimal currentPrice,
            long marketCap,
            int marketCapRank,
            long fullyDilutedValuation,
            long totalVolume,
            decimal? high24h,
            decimal? low24h,
            decimal? priceChange24h,
            decimal? priceChangePercentage24h,
            decimal? marketCapChange24h,
            decimal? marketCapChangePercentage24h,
            decimal? circulatingSupply,
            decimal? totalSupply,
            decimal? maxSupply,
            decimal? ath,
            decimal? athChangePercentage,
            DateTime? athDate,
            decimal? atl,
            decimal? atlChangePercentage,
            DateTime? atlDate
            )
        {
            Id = id;
            Symbol = symbol;
            Name = name;
            Image = image;
            CurrentPrice = currentPrice;
            MarketCap = marketCap;
            MarketCapRank = marketCapRank;
            FullyDilutedValuation = fullyDilutedValuation;
            TotalVolume = totalVolume;
            High24h = high24h;
            Low24h = low24h;
            PriceChange24h = priceChange24h;
            PriceChangePercentage24h = priceChangePercentage24h;
            MarketCapChange24h = marketCapChange24h;
            MarketCapChangePercentage24h = marketCapChangePercentage24h;
            CirculatingSupply = circulatingSupply;
            TotalSupply = totalSupply;
            MaxSupply = maxSupply;
            Ath = ath;
            AthChangePercentage = athChangePercentage;
            AthDate = athDate;
            Atl = atl;
            AtlChangePercentage = atlChangePercentage;
            AtlDate = atlDate;
            Currency = "USD";
        }

        public void SetCurrency(string currency)
        {
            Currency = currency;
        }

        public bool HasChanged(CryptoCurrency cryptoCurrency)
        {
            //Just considering id and currentprice, although new especific rules can be aplyied here
            return Id == cryptoCurrency.Id && CurrentPrice != cryptoCurrency.CurrentPrice;
        }

        public void Update(CryptoCurrency cryptoCurrency)
        {
            Symbol = cryptoCurrency.Symbol;
            Name = cryptoCurrency.Name;
            Image = cryptoCurrency.Image;
            CurrentPrice = cryptoCurrency.CurrentPrice;
            MarketCap = cryptoCurrency.MarketCap;
            MarketCapRank = cryptoCurrency.MarketCapRank;
            FullyDilutedValuation = cryptoCurrency.FullyDilutedValuation;
            TotalVolume = cryptoCurrency.TotalVolume;
            High24h = cryptoCurrency.High24h;
            Low24h = cryptoCurrency.Low24h;
            PriceChange24h = cryptoCurrency.PriceChange24h;
            PriceChangePercentage24h = cryptoCurrency.PriceChangePercentage24h;
            MarketCapChange24h = cryptoCurrency.MarketCapChange24h;
            MarketCapChangePercentage24h = cryptoCurrency.MarketCapChangePercentage24h;
            CirculatingSupply = cryptoCurrency.CirculatingSupply;
            TotalSupply = cryptoCurrency.TotalSupply;
            MaxSupply = cryptoCurrency.MaxSupply;
            Ath = cryptoCurrency.Ath;
            AthChangePercentage = cryptoCurrency.AthChangePercentage;
            AthDate = cryptoCurrency.AthDate;
            Atl = cryptoCurrency.Atl;
            AtlChangePercentage = cryptoCurrency.AtlChangePercentage;
            AtlDate = cryptoCurrency.AtlDate;
            Currency = cryptoCurrency.Currency;
        }
    }
}
