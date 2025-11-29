namespace Garage.Library
{
    public abstract class Application(
        string name) 
        : IApplication
    {
        public string Name { get; } = name;
        public abstract ApplicationStatus Run();
    }
}
