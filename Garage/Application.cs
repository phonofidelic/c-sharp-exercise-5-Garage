using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public abstract class Application
    {
        public ApplicationStatus Status { get; private set; } = new(1);

        public Exception? Exception { get; private set; }

        public abstract ApplicationStatus Start();
        // Todo:
        //public abstract ApplicationStatus Start(ApplicationConfig config);
    }
}
