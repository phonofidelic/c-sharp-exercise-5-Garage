namespace Garage.Library
{
    public class ApplicationManager()
    {
        private List<IApplication> _applications = [];

        public void Start()
        {
            Parallel.ForEach(_applications, (app) => app.Run());
        }

        public void Add(IApplication app)
        {
            _applications.Add(app);
        }
    }
}
