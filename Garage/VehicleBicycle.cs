namespace Garage
{
    internal class VehicleBicycle(VehicleProperties bicycleProperties)
        : Vehicle("Bicycle", bicycleProperties)
    {}

    internal record BicycleProperties(
        string Make,
        string Color) : VehicleProperties(
            Make,
            Color,
            VehicleType.Bicycle);
}
