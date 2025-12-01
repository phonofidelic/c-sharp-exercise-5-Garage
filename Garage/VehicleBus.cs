namespace Garage
{
    internal class VehicleBus(VehicleProperties busProperties)
        : Vehicle("Bus", busProperties)
    {}

    internal record BusProperties(
        string Make,
        string VIN,
        string Color) : VehicleProperties(
            Make,
            Color,
            VehicleType.Bus);
}
