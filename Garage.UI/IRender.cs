namespace Garage.UI
{
    public delegate void RenderCallback<T>(T message);
    public interface IRender
    {
        public virtual void Render() { }
        public virtual void Render<T>(Action<T>? action) { }
    }
}