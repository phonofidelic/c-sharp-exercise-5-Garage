namespace Garage.UI
{
    public interface IRender
    {
        public void Render();
    }

    public delegate void RenderCallback<T>(T props);
    public interface IInput
    {
        public string? Render();
    }
}