namespace Garage
{
    public record ListParkedVehiclesResponseDTO(
        Queue<Vehicle> Vehicles
    );
}

