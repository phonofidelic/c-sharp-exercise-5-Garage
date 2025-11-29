using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Library
{
    public abstract class ApplicationEventHandler<TEvent>(ILogger logger) : IHandler where TEvent : ApplicationEvent
    {
        protected ApplicationEventHandler<TEvent>? Next { get; set; } = null;
        protected abstract void _handle<T>(T @event) where T : ApplicationEvent;
        public virtual void Handle<T>(T @event) where T : ApplicationEvent
        {
            // Check if the concrete handler can handle the event
            logger.LogInformation("Checking if handler can handle event: {Event}, {CanHandle}", @event, @event.GetType() == typeof(TEvent));
            logger.LogInformation("Handler event type: {EventType}", typeof(TEvent));
            logger.LogInformation("Target event type: {EventType}", @event);
            if (@event.GetType() == typeof(TEvent))
            {
                _handle(@event);
            }
        }

        public abstract void SetNext(IHandler handler);
    }
}
