using Garage.Library;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class GarageAPI(IEventBus eventBus, ILogger<GarageAPI> logger) : Application("Garage API", eventBus), IAPI
    {
        public ResponseGarageCreateDTO CreateNewGarage(RequestGarageCreateDTO requestCreate)
        {
            return new(requestCreate.Name);
        }

        public override ApplicationStatus Run()
        {
            logger.LogInformation("Running {Name}", Name);
            return new(1);
        }

        public void ProcessRequest(ApplicationEvent request)
        {
            switch (request.Type)
            {
                case GarageRequestType.GarageCreate:
                    // ToDo: Handle request
                    Console.WriteLine($"### Processing request: {GarageRequestType.GarageCreate}");
                    //eventBus.PublishAsync()
                    break;
                default:
                    break;
            }
        }
    }

    public enum GarageRequestType
    {
        GarageCreate
    }
}
