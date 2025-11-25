using System.Collections;

namespace Garage.Library
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public int Capacity { get; private set; }
        public int Count { get; private set; }
        private IEnumerable<T> _vehicles;

        public Garage(int capacity)
        {
            Capacity = capacity;
            _vehicles = [];
        }

        public int Add(T vehicle)
        {
            if (Count < Capacity)
            {
                _vehicles = [.._vehicles, vehicle];
                Count++;
                Capacity--;
                return 1;
            }
            return 0;
        }

        public int Remove(T vehicle)
        {
            var toRemove = _vehicles.FirstOrDefault(v => v.VIN == vehicle.VIN);
            if (toRemove != null)
            {
                toRemove = null;
                Count--;
                Capacity++;
                return -1;
            }
            return 0;
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
