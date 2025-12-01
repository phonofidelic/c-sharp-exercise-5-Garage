namespace Garage
{
    public record ParkNewVehicleDTO(
        string Make,
        string VIN,
        string Color)
        : VehicleProperties(
            Make,
            VIN,
            Color)
    { };
}