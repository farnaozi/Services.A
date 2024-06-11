using Services.A.Core.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Services.A.Core.Interfaces
{
    public interface IEventHandler<in TEvent> : IEventHandler
         where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
