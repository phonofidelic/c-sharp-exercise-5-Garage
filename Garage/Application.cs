using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public abstract class Application(string name)
    {
        public string Name { get; } = name;
        public ApplicationStatus Status { get; private set; } = new(1);

        public Exception? Exception { get; private set; }

        public abstract ApplicationStatus Run();
        // Todo:
        //public abstract ApplicationStatus Start(ApplicationConfig config);
    }
}
