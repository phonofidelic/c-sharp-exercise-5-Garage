using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Garage
{
    public class GarageApplication(string name, ChannelReader<ApplicationMessage> reader) : Application(name, reader)
    {
        public override ApplicationStatus Run() {
            do
            {
                Console.WriteLine("Running Garage app");
                Console.ReadKey();
                return new ApplicationStatus(1);
            } while(true);
        }
    }
}
