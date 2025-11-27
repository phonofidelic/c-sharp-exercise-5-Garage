using System.Collections;

namespace Garage.Library
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public Guid Id { get; init; }
        public int Capacity { get; private set; }
        public int Count { get; private set; }
        private Array _vehicles;

        public Garage(int capacity)
        {
            Capacity = capacity;
            _vehicles = new Vehicle[capacity];
        }

        public void Add(T vehicle)
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
            while(index < Capacity)
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
