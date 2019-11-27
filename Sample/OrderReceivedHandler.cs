using System;
using System.Threading.Tasks;
using NServiceBus;

public class OrderReceivedHandler :
    IHandleMessages<OrderReceived>
{
    public Task Handle(OrderReceived message, IMessageHandlerContext context)
    {
        Console.WriteLine($"Subscriber has received OrderReceived event with OrderId {message.OrderId}.");
        return Task.CompletedTask;
    }
}