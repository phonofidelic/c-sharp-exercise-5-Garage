namespace Garage.UI
{
    public delegate void RenderCallback<T>(T message);
    public interface IRender
    {
        public void Render();
    }
}