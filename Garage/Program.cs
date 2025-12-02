using Garage.Library;
using Garage.UI;
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
                services.AddSingleton<MessageQueue>();
                services.AddHostedService<ApplicationEventProcessorJob>();
                services.AddSingleton<IEventBus, EventBus>();
                services.AddSingleton<IApplicationRequest, ApplicationRequest>();
                services.AddSingleton<IApplicationManager, ApplicationManager>();
                services.AddSingleton<IUI, GarageUIApplication>();
                // ToDo: Implement concrete event handlers as scoped services?
                // Register event handlers
                services.AddSingleton<CreateGarageRequestEventHandler>();
                services.AddSingleton<CreateGarageResponseEventHandler>();
                services.AddSingleton<ParkNewVehicleRequestEventHandler>();
                services.AddSingleton<ListParkedVehiclesRequestEventHandler>();
                services.AddSingleton<ListParkedVehicleResponseEventHandler>();
                // Register data entities
                services.AddSingleton<CreateGarageRequestDTO>();
                services.AddSingleton<ParkNewVehicleRequestDTO>();
                services.AddSingleton<ListParkedVehiclesDTO>();
                services.AddSingleton<Garage.Garage<Vehicle>, Garage<Vehicle>>();
                // Register UI components
                services.AddSingleton<MainMenu>();
                services.AddSingleton<CreateNewGarageForm>();
                services.AddSingleton<ListVehiclesView>();
                services.AddSingleton<ListVehiclesMenu>();
                services.AddSingleton<ParkNewVehicleForm>();
                services.AddSingleton<RemoveVehicleMenu>();
                services.AddSingleton<CreateGarageResponseSuccessScreen>();
            })
            .UseConsoleLifetime();

            IHost host = builder.Build();
            Task task = host.StartAsync();

            IApplicationManager manager = host.Services.GetRequiredService<IApplicationManager>();
            manager.Add(host.Services.GetRequiredService<IUI>());
            manager.Add(host.Services.GetRequiredService<CreateGarageRequestEventHandler>());
            manager.Add(host.Services.GetRequiredService<CreateGarageResponseEventHandler>());
            manager.Add(host.Services.GetRequiredService<ParkNewVehicleRequestEventHandler>());
            manager.Add(host.Services.GetRequiredService<ListParkedVehiclesRequestEventHandler>());
            manager.Add(host.Services.GetRequiredService<ListParkedVehicleResponseEventHandler>());
            manager.Start();

        }
    }
}
