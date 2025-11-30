using Garage.Library;
using System.Collections;

namespace Garage
{
    public class Garage<T> : ApplicationStorage<T>, IEnumerable<T>, IStorage<T> where T : Vehicle
    {
        public Guid Id { get; init; }
        private string _name { get; set;}
        public string Name
        {
            get => new(_name);
            private set => _name = value;
        }
        public int Capacity { get; private set; }
        public int Count { get; private set; }
        private Array _vehicles;

        public Garage()
        {
            _name = "Default Garage";
            Capacity = 50;
            _vehicles = new Vehicle[50];
        }

        public void Init(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            _vehicles = new Vehicle[capacity];
        }

        public override List<T> GetAll()
        {
            List<T> tempList = [];
            foreach (T vehicle in _vehicles)
            {
                tempList.Add(vehicle);
            }
            return tempList;
        }

        public override void Add(T vehicle)
        {
            if (Count < Capacity)
            {
                if (_vehicles.GetValue(Count) != null)
                    throw new Exception($"Index {Count} is not empty");

                _vehicles.SetValue(vehicle, Count);
                Count++;
                Capacity--;
            }
        }

        public void Remove(T vehicle)
        {
            int vehicleIndex = FindVehicleIndex(vehicle);
            if (vehicleIndex < 0)
                throw new Exception($"No item present at index {vehicleIndex}");
            _vehicles.SetValue(null, vehicleIndex);
            Count--;
            Capacity++;
        }

        private int FindVehicleIndex(Vehicle vehicle)
        {
            int index = 0;
            object? itemAtIndex = null;
            while (index < Capacity)
            {
                itemAtIndex = _vehicles.GetValue(index);
                if (itemAtIndex != null && itemAtIndex.Equals(vehicle))
                {
                    break;
                }
                index++;
            }
            if (itemAtIndex == null || !itemAtIndex.Equals(vehicle))
            {
                return -1;
            }
            return index;
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in _vehicles)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
