using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Library
{
    public interface IAPI : IApplication
    {
        //ResponseGarageCreateDTO CreateNewGarage(CreateGarageRequestDTO requestCreate);
        ApplicationEvent RouteEvent(ApplicationEvent request);
    }


}
