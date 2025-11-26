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
    }
}
