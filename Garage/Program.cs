using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Channels;

namespace Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var channel = Channel.CreateBounded<ApplicationMessage>(1);

            IHostBuilder builder = Host.CreateDefaultBuilder(args);
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<ApplicationManager>();
                services.AddSingleton<GarageUIApplication>(new GarageUIApplication("Garage UI", channel.Writer));
                //services.AddSingleton<GarageApplication>(new GarageApplication("Garage", channel.Reader));
            })
            .UseConsoleLifetime();
            IHost host = builder.Build();
            //host.Run();

            //host.Services.GetRequiredService<GarageApplication>().Run();
            host.Services.GetRequiredService<GarageUIApplication>().Run();
            host.Services.GetRequiredService<ApplicationManager>().Start(channel);
            host.Run();

            //ApplicationManager applicationManager = new();
            //applicationManager.Start();
        }
    }
}
