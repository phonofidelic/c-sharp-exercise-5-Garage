namespace Garage
{
    internal interface IParkable
    {
        Vehicle Park<T>(T vehicleDTO);
    }
}