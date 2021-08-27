using MediatR;
using Microsoft.AspNetCore.SignalR;
using RightStakes.Challenge.Domain.Notifications;
using RightStakes.Challenge.Services.WebAPI.Hubs;
using System.Threading;
using System.Threading.Tasks;

namespace RightStakes.Challenge.Services.WebAPI.Handlers
{
    public class CurrencyHandler :
        INotificationHandler<CryptoCurrencyChangedNotification>,
        INotificationHandler<QuoteChangedNotification>
    {
        private readonly IHubContext<CurrencyHub> _currencyHub;

        public CurrencyHandler(IHubContext<CurrencyHub> currencyHub)
        {
            _currencyHub = currencyHub;
        }

        public Task Handle(CryptoCurrencyChangedNotification notification, CancellationToken cancellationToken)
        {
            return _currencyHub.Clients.All.SendCoreAsync("cryptocurrencyhasupdated", new object[] { notification });
        }

        public Task Handle(QuoteChangedNotification notification, CancellationToken cancellationToken)
        {
            return _currencyHub.Clients.All.SendCoreAsync("currencyconvertionhasupdated", new object[] { notification });
        }
    }
}
