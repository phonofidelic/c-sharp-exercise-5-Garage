namespace Garage
{
    public abstract class Vehicle : IParkable
    {
        private Guid _id { get; init; }
        public string Id  { get => _id.ToString(); }

        private string _name;
        public int Location { get; protected set; }
        public string Name
        {
            get => new(_name);
            private set => _name = value;
        }

        public VehicleProperties Props { get; private set; }

        public Vehicle(string name, VehicleProperties props)
        {
            _id = Guid.NewGuid();
            _name = name;
            Props = props;
        }

        // Return index position in Garage
        public virtual void Park(int space)
        {
            Location = space;
        }
    }
    public abstract record VehicleProperties(
        string Make,
        string Color,
        VehicleType Type);

    public enum VehicleType
    {
        Car,
        Bus,
        Bicycle
    }
}

