using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public abstract class Application(string name)
    {
        public ConsoleColor LogColor = ConsoleColor.Cyan;
        public string Name { get; } = name;
        public string LogName { get; private init; } = name.ToUpper().Replace(' ', '_');
        public ApplicationStatus Status { get; private set; } = new(0);
        public Exception? Exception { get; private set; }
        public abstract ApplicationStatus Run();
    }
}
