using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;

public class Program
{
    static async Task Main()
    {
        Console.Title = "Press Ctrl-C to exit...";
        using var host = Host.CreateDefaultBuilder()
            .UseNServiceBus(BuildEndpoint)
            .UseContentRoot(AppDomain.CurrentDomain.BaseDirectory)
            .ConfigureServices((hostContext, services) => services.AddHostedService<DoPublish>())
            .UseConsoleLifetime()
            .Build();
        await host.RunAsync();
    }

    public static EndpointConfiguration BuildEndpoint(HostBuilderContext hostContext)
    {
        var endpoint = new EndpointConfiguration("Sample");
        endpoint.UsePersistence<LearningPersistence>();
        endpoint.UseTransport<LearningTransport>();
        return endpoint;
    }

}