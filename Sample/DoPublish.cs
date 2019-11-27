using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using NServiceBus;

public class DoPublish : IHostedService
{
    IServiceProvider serviceProvider;

    public DoPublish(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var orderReceived = new OrderReceived
        {
            OrderId = Guid.NewGuid()
        };
        return ((IMessageSession)serviceProvider.GetService(typeof(IMessageSession))).Publish(orderReceived);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}