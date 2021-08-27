using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RightStakes.Challenge.Domain.Entities;
using RightStakes.Challenge.Services.Crawler.Models;
using System;

namespace RightStakes.Challenge.Services.WebAPI.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CryptoCurrencyModel, CryptoCurrency>().ConstructUsing(model =>
                        new CryptoCurrency(model.Id, model.Symbol, model.Name, model.Image, model.CurrentPrice, model.MarketCap, model.MarketCapRank, model.FullyDilutedValuation, model.TotalVolume, model.High24h, model.Low24h, model.PriceChange24h, model.PriceChangePercentage24h, model.MarketCapChange24h, model.MarketCapChangePercentage24h, model.CirculatingSupply, model.TotalSupply, model.MaxSupply, model.Ath, model.AthChangePercentage, model.AthDate, model.Atl, model.AtlChangePercentage, model.AtlDate)
                    );
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
