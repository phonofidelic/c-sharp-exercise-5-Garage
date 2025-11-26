using Garage.Library;

namespace Garage
{
    internal record Store(string name) : IGarageStore
    {
        public Guid Id { get; init; }
        public string Name { get; private set; } = name;
        public void Add(Garage<Vehicle> garage)
        {
            throw new NotImplementedException();
        }
    }
}