using Garage.Library;
using Microsoft.Extensions.Logging;
using System.Collections;

namespace Garage
{
    internal class Garage<TData> 
        : IEnumerable<TData>, IStorage<TData> where TData : Vehicle
    {
        private ILogger<Garage<TData>> _logger;
        private Guid Id { get; init; }
        private string _name { get; set;}
        public string Name
        {
            get => new(_name);
            private set => _name = value;
        }
        public int Capacity { get; private set; }
        public int Count { get; private set; }
        private Array _vehicles;

        public Garage(
            //IApplicationRequest request,
            ILogger<Garage<TData>> logger)
        {
            _logger = logger;
            _name = "Default Garage";
            Capacity = 50;
            _vehicles = new Vehicle[50];

            // Populate the garage
            Park(new(
                make: "Toyota",
                color: "Black",
                type: VehicleType.Car,
                vin: "ABC-123"));
            Park(new(
                make: "Volkswagen",
                color: "Yellow",
                type: VehicleType.Bus,
                vin: "XYZ-321"));
        }

        public void Init(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            _vehicles = new Vehicle[capacity];
        }

        public Queue<TData> GetAll()
        {
            _logger.LogDebug("GetAll: {list}", _vehicles);
            Queue<TData> tempList = [];
            foreach (TData vehicle in _vehicles)
            {
                tempList.Enqueue(vehicle);
            }
            return tempList;
        }

        internal int Park(ParkNewVehicleRequestDTO vehicleDTO)
        {
            Vehicle newVehicle;

            switch (vehicleDTO.Type)
            {
                case VehicleType.Car:
                    newVehicle = new VehicleCar(new(
                        vehicleDTO.Make,
                        vehicleDTO.VIN,
                        vehicleDTO.Color));
                    break;

                case VehicleType.Bicycle:
                    newVehicle = new VehicleBicycle(vehicleDTO);
                    break;

                case VehicleType.Bus:
                    newVehicle = new VehicleBus(vehicleDTO);
                    break;

                default:
                    throw new Exception($"Unsupported vehicle type: {vehicleDTO.Type}");

            }

            
            return Add((TData)newVehicle);
        }

        public int Add(TData newVehicle) 
        {
            if (Count >= Capacity)
            {
                throw new Exception("The garage is full");
            }

            if (_vehicles.GetValue(Count) != null)
                throw new Exception($"Index {Count} is not empty");

            newVehicle.Park(Count);
            _vehicles.SetValue(newVehicle, Count);
            Count++;
            Capacity--;

            return Count;
        }

        public void Remove(TData vehicle)
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
        public IEnumerator<TData> GetEnumerator()
        {
            foreach (TData item in _vehicles)
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
