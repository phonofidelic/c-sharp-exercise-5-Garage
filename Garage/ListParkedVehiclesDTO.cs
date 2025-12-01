using Garage;
using Garage.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal record ListParkedVehiclesDTO(
        List<Vehicle> Vehicles);
    //internal record ListParkedVehiclesDTO : VehicleProperties
    //{
    //    internal string? VIN = null;

    //    // Car and Bus DTO
    //    public ListParkedVehiclesDTO(
    //        string make,
    //        string vin,
    //        string color,
    //        VehicleType type)
    //        : base(
    //        make,
    //        color,
    //        type)
    //    {
    //        Make = make;
    //        VIN = vin;
    //        Color = color;
    //        Type = type;
    //    }

    //    // Bicycle DTO
    //    public ListParkedVehiclesDTO(
    //        string make,
    //        string color,
    //        VehicleType type)
    //        : base(
    //        make,
    //        color,
    //        VehicleType.Bicycle)
    //    {
    //        Make = make;
    //        VIN = null;
    //        Color = color;
    //        Type = VehicleType.Bicycle;
    //    }
    //}
}

