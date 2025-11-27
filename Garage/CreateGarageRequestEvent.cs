
using Garage.Library;
using System;

namespace Garage
{
    internal class CreateGarageRequestEvent : ApplicationEvent
    {
        //public Guid Id { get; init; }
        //public override GarageCreateDTO Payload { get; private set; }
        public CreateGarageRequestEvent(RequestGarageCreateDTO garageCreate)
            : base(GarageRequestType.GarageCreate, garageCreate) { }
        //{
        //    //Id = Guid.NewGuid();
        //    Payload = garageCreate;
        //}
    }
}