using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Library
{
    public interface IApplication
    //public interface IApplication<TEvent> : IHandler<TEvent> where TEvent : ApplicationEvent
    {
        public ApplicationStatus Run();
        public void Handle(ApplicationEvent @event);
    }
}
