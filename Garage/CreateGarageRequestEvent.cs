
using Garage.Library;
using System;

namespace Garage
{
    internal class CreateGarageRequestEvent(RequestGarageCreateDTO garageCreate) 
        : ApplicationEvent(GarageRequestType.GarageCreate, garageCreate)
    {}
}