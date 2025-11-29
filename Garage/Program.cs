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
                services.AddSingleton<MessageQueue>();
                services.AddHostedService<ApplicationEventProcessorJob>();
                services.AddSingleton<IGarageStore>(new Store("My Garage"));
                services.AddSingleton<IEventBus, EventBus>();
                services.AddSingleton<IApplicationRequest, ApplicationRequest>();
                services.AddSingleton<IApplicationManager, ApplicationManager>();
                services.AddSingleton<IUI, GarageUIApplication>();
                // ToDo: Implement concrete event handlers as scoped services?
                // Register event handlers
                services.AddSingleton<CreateGarageRequestEventHandler>();
                services.AddSingleton<CreateGarageResponseEventHandler>();
                // Register UI components
                services.AddSingleton<MainMenu>();
                services.AddSingleton<CreateGarageMenu>();
                services.AddSingleton<CreateGarageResponseSuccessScreen>();
            })
            .UseConsoleLifetime();

            IHost host = builder.Build();
            Task task = host.StartAsync();

            IApplicationManager manager = host.Services.GetRequiredService<IApplicationManager>();
            manager.Add<ApplicationEvent>(host.Services.GetRequiredService<IUI>());
            manager.Add(host.Services.GetRequiredService<CreateGarageRequestEventHandler>());
            manager.Add(host.Services.GetRequiredService<CreateGarageResponseEventHandler>());
            manager.Start();

        }
    }
}
