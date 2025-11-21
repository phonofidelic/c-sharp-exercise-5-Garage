using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class GarageApplication(string name) : Application(name)
    {
        public override ApplicationStatus Run() {
            return new(1);
        }
    }
}
