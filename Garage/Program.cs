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
                services.AddSingleton<IGarageStore>(new Store("My Garage"));
                services.AddSingleton<MessageQueue>();
                services.AddSingleton<IEventBus, EventBus>();
                services.AddSingleton<IApplicationRequest, ApplicationRequest>();
                // ToDo: Implement concrete event handlers as scoped services?
                services.AddSingleton<CreateGarageRequestEventHandler>();
                services.AddSingleton<CreateGarageResponseEventHandler>();
                services.AddSingleton<IApplicationManager, ApplicationManager>();
                services.AddHostedService<ApplicationEventProcessorJob>();
                services.AddSingleton<IUI, GarageUIApplication>();
                services.AddSingleton<MainMenu>();
                services.AddSingleton<CreateGarageMenu>();
            })
            .UseConsoleLifetime();

            IHost host = builder.Build();
            Task task = host.StartAsync();

            IApplicationManager manager = host.Services.GetRequiredService<IApplicationManager>();
            manager.Add<ApplicationEvent>(host.Services.GetRequiredService<IUI>());
            manager.Add<ApplicationEvent>(host.Services.GetRequiredService<CreateGarageRequestEventHandler>());
            manager.Start();

        }
    }
}
