using System;

namespace Garage.Library;

public abstract class Vehicle
{
    public string VIN { get; private set; }
    
    public Vehicle(string vin)
    {
        VIN = vin;
    }
}
