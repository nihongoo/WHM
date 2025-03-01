using hoicham.Core.Domain.Events;

namespace hoicham.Core.Ports.Output.Services
{
    public interface IEventHandler<T> where T : IDomainEvent
    {
        Task HandleAsync(T domainEvent);
    }
}
