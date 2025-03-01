using hoicham.Core.Domain.Events;

namespace hoicham.Core.Ports.Output.Services
{
    public interface IEventDispatcher
    {
        Task DispatchAsync<T>(T domainEvent) where T : IDomainEvent;
        void Register<T>(IEventHandler<T> handler) where T : IDomainEvent;
    }
}
