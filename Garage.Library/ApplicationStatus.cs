namespace Garage.Library
{
    public record ApplicationStatus(
        int Code, 
        Exception? Exception = null);
}