using Garage.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class GarageAPI() : IAPI
    {
        public ResponseGarageCreateDTO CreateNewGarage(RequestGarageCreateDTO requestCreate)
        {
            return new(requestCreate.Name);
        }

        public void ProcessRequest(ApplicationEvent request)
        {
            switch (request.Type)
            {
                case GarageRequestType.GarageCreate:
                    Console.WriteLine($"### Processing request: {GarageRequestType.GarageCreate}");
                    break;
                default:
                    break;
            }
        }

        //public void ProcessRequest<T>(ApplicationEvent<T> request) where T : Enum
        //{
        //    throw new NotImplementedException();
        //}

        //// public void ProcessRequest(Enum requestType)
        //// {
        ////     throw new NotImplementedException();
        //// }
    }

    public enum GarageRequestType
    {
        GarageCreate
    }
}
