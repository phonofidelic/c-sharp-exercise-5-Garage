namespace Garage
{
    public record CreateGarageResponseDTO(
        string Name,
        int Capacity,
        List<Guid> Vehicles);
}