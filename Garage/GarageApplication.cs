using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Garage.Library;

namespace Garage
{
    internal class GarageApplication(IEventBus eventBus) 
        : Application("Garage", eventBus)
    {
        public override ApplicationStatus Run() {
            do
            {
                Console.WriteLine("Running Garage app");
                //Console.ReadKey();
                //GarageCreateCommandHandler garageCreate = new();
                //garageCreate.Handle();
                return new ApplicationStatus(1);
            } while(true);
        }
    }
}
