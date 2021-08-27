using MediatR;
using RightStakes.Challenge.Domain.Entities;
using System;

namespace RightStakes.Challenge.Domain.Notifications
{
    public class CryptoCurrencyChangedNotification : INotification
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

        public CryptoCurrencyChangedNotification(CryptoCurrency cryptoCurrency)
        {
            Id = cryptoCurrency.Id;
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
        }
    }
}
