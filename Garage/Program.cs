using Garage.Library;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHostBuilder builder = Host.CreateDefaultBuilder(args);
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IAPI, GarageAPI>();
                services.AddSingleton<IGarageStore>(new Store("My Garage"));
                services.AddSingleton<MessageQueue>();
                services.AddSingleton<IEventBus, EventBus>();
                services.AddHostedService<ApplicationEventProcessorJob>();
                services.AddSingleton<IUI, GarageUIApplication>();
            })
            .UseConsoleLifetime();

            IHost host = builder.Build();
            Task task = host.StartAsync();

            ApplicationManager manager = new();
            manager.Add(host.Services.GetRequiredService<IUI>());
            manager.Add(host.Services.GetRequiredService<IAPI>());
            manager.Start();

        }
    }
}
