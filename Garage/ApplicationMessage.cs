namespace Garage
{
    public class ApplicationMessage(string name)
    {
        public string Name { get; private set; } = name;
    }
}