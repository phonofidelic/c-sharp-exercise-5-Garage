using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Library
{
    public class GarageAPI() : IGarageAPI
    {
        public ResponseGarageCreateDTO CreateNewGarage(RequestGarageCreateDTO requestCreate)
        {
            return new(requestCreate.Name);
        }

        public void ProcessRequest<T>(T requestType) where T : Enum
        {
            switch (requestType)
            {
                case GarageRequestType.GarageCreate:
                    Console.WriteLine($"### Processing request: {GarageRequestType.GarageCreate}");
                    break;
                default:
                    break;
            }
        }

        // public void ProcessRequest(Enum requestType)
        // {
        //     throw new NotImplementedException();
        // }
    }

    public enum GarageRequestType
    {
        GarageCreate
    }
}
