using hoicham.Core.Domain.Events;

namespace hoicham.Core.Ports.Output
{
    public interface IAggregateRoot
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
        void ClearDomainEvents();
    }
}
