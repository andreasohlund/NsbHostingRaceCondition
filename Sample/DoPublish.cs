using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using NServiceBus;

public class DoPublish : IHostedService
{
    IMessageSession session;

    public DoPublish(IMessageSession session)
    {
        this.session = session;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var orderReceived = new OrderReceived
        {
            OrderId = Guid.NewGuid()
        };
        return session.Publish(orderReceived);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}