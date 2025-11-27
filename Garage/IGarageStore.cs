using Garage.Library;

namespace Garage
{
    internal interface IGarageStore
    {
        void Add(Garage.Library.Garage<Vehicle> garage);
    }
}