using BuberDinner.Domain.MenuAggregate.Events;

using MediatR;

namespace BuberDinner.Application.Dinners.Events;

public class DummyHandler : INotificationHandler<MenuCreated>
{
    public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
