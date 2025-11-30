using System;

namespace Garage
{
    public abstract class Vehicle
    {
        private Guid _id;

        public VehicleProperties Props { get; private set; }

        public Vehicle(VehicleProperties props)
        {
            _id = Guid.NewGuid();
            Props = props;
        }

        // Return index position in Garage
        public abstract int Park();
    }
    public abstract record VehicleProperties()
    {
        string Make;
        string Vin;
        string Color;
    }
}

