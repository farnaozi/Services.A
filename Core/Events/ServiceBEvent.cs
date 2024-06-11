using Services.A.Core.Models;

namespace Services.A.Core.Events
{
    public class ServiceBEvent : Event
    {
        public string Message { get; set; }
    }
}
