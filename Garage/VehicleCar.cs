namespace Garage
{
    internal class VehicleCar(CarProperties carProperties)
        : Vehicle("Car", carProperties)
    {}

    internal record CarProperties(
        string Make,
        string VIN,
        string Color) : VehicleProperties(
            Make,
            Color,
            VehicleType.Car);
}
