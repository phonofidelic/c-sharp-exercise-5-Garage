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
                services.AddSingleton<IGarageAPI, GarageAPI>();
                services.AddSingleton<IGarageStore>(new Store("My Garage"));
                services.AddSingleton<MessageQueue>();
                services.AddSingleton<IEventBus, EventBus>();
                services.AddHostedService<ApplicationEventProcessorJob>();
                services.AddSingleton<GarageUIApplication>();
                services.AddSingleton<GarageApplication>();
                //services.AddSingleton<ICreateHandler<Lib.Garage<Lib.Vehicle>>>(new GarageCreateCommandHandler());
            })
            .UseConsoleLifetime();

            IHost host = builder.Build();
            host.StartAsync();

            //host.Services.GetRequiredService<GarageUIApplication>().Run();
            //host.Services.GetRequiredService<GarageApplication>().Run();
            
            List<Application> apps = [];
            apps.Add(host.Services.GetRequiredService<GarageUIApplication>());
            apps.Add(host.Services.GetRequiredService<GarageApplication>());
            Parallel.ForEach(apps, (app) => app.Run());

            //ApplicationManager applicationManager = new();
            //applicationManager.Start();
        }
    }
}
