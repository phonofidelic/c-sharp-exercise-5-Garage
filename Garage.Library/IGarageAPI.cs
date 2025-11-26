using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Library
{
    public interface IGarageAPI
    {
        ResponseGarageCreateDTO CreateNewGarage(RequestGarageCreateDTO requestCreate);
        void ProcessRequest(RequestType requestType);
    }

    public enum RequestType
    {
        GarageCreate
    }
}
