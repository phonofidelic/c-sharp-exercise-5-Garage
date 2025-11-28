using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Library
{
    public abstract class ApplicationEventHandler<TEvent> : IHandler<TEvent> where TEvent : ApplicationEvent
    {
        protected abstract void _handle(TEvent @event);
        public virtual void Handle(TEvent @event)
        {
            // Check if the concrete handler can handle the event
            if (@event.GetType() == typeof(TEvent))
            {
                _handle(@event);
            }
        }

        public abstract void SetNext(IHandler<TEvent> handler);
    }
}
