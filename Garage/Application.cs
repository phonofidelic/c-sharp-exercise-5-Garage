using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Garage.Library;

namespace Garage
{
    public abstract class Application(string name, IEventBus eventBus)
    {
        public ConsoleColor LogColor = ConsoleColor.Cyan;
        public string Name { get; } = name;
        protected IEventBus _eventBus { get; } = eventBus;
        public string LogName { get; private init; } = name.ToUpper().Replace(' ', '_');
        public ApplicationStatus Status { get; private set; } = new(0);
        public Exception? Exception { get; private set; }
        public abstract ApplicationStatus Run();

        public virtual async Task RunAsync()
        {
            await Task.Run(Run);
        }
    }
}
