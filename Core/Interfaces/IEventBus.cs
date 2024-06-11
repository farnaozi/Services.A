using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Services.A.Core.Models;
using Services.A.Core.Enums;

namespace Services.A.Core.Interfaces
{
    public interface IEventBus
    {
        void Publish<T>(T @event, ExchangeTypes exchangeType, bool createQueue = true) where T : Event;

        void Subscribe<T, TH>(ExchangeTypes exchangeType)
            where T : Event
            where TH : IEventHandler<T>;
    }
}
