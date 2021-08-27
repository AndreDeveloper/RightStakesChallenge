using MediatR;
using RightStakes.Challenge.Domain.Entities;
using System;

namespace RightStakes.Challenge.Domain.Notifications
{
    public class QuoteChangedNotification : INotification
    {
        public string Name { get; private set; }

        public decimal? Value { get; private set; }

        public DateTime LastUpdate { get; private set; }

        public QuoteChangedNotification(Quote quote)
        {
            Name = quote.Name;
            Value = quote.Value;
            LastUpdate = quote.LastUpdate;
        }
    }
}
