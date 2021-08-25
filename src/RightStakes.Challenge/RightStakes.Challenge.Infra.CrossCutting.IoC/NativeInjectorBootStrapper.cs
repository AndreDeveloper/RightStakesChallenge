using Microsoft.Extensions.DependencyInjection;
using RightStakes.Challenge.Domain.Interfaces.Repositories;
using RightStakes.Challenge.Infra.Data.Context;
using RightStakes.Challenge.Infra.Data.Repository;
using RightStakes.Challenge.Services.Crawler.Interfaces;
using RightStakes.Challenge.Services.Crawler.Services;

namespace RightStakes.Challenge.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection container)
        {
            Repositories(container);
            Services(container);
        }

        private static void Repositories(IServiceCollection container)
        {
            container.AddScoped<RightStakesContext>();
            container.AddScoped<ICryptoCurrencyRepository, CryptoCurrencyRepository>();
            container.AddScoped<IQuoteRepository, QuoteRepository>();
        }

        private static void Services(IServiceCollection container)
        {
            container.AddSingleton<ICoingeckoService, CoingeckoService>();
            container.AddSingleton<ICurrencyLayerService, CurrencyLayerService>();
        }
    }
}
