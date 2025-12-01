using System.Drawing;

namespace Garage
{
    internal record ParkNewVehicleRequestDTO : VehicleProperties 
    {
        internal string? VIN = null;

        // Car and Bus DTO
        public ParkNewVehicleRequestDTO(
            string make,
            string vin,
            string color,
            VehicleType type)   
            : base(
            make,
            color,
            type)
        {
            Make = make;
            VIN = vin;
            Color = color;
            Type = type;
        }

        // Bicycle DTO
        public ParkNewVehicleRequestDTO(
            string make,
            string color,
            VehicleType type)
            : base(
            make,
            color,
            VehicleType.Bicycle)
        {
            Make = make;
            VIN = null;
            Color = color;
            Type = VehicleType.Bicycle;
        }
    } 
}