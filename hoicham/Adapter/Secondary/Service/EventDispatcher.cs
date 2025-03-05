using hoicham.Core.Domain.Events;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Adapter.Secondary.Service
{
	public class EventDispatcher : IEventDispatcher
	{
		private readonly Dictionary<Type, List<object>> _handlers = new Dictionary<Type, List<object>>();
		private readonly ILoggerService _logger;

		public EventDispatcher(ILoggerService logger)
		{
			_logger = logger;
		}

		public async Task DispatchAsync<T>(T domainEvent) where T : IDomainEvent
		{
			var eventType = typeof(T);
			_logger.LogInformation("Dispatching event of type {EventType} with ID {EventId}", eventType.Name, domainEvent.Id);

			if (!_handlers.ContainsKey(eventType))
			{
				_logger.LogWarning("No handlers registered for event type {EventType}", eventType.Name);
				return;
			}

			foreach (var handler in _handlers[eventType])
			{
				try
				{
					var typedHandler = (IEventHandler<T>)handler;
					await typedHandler.HandleAsync(domainEvent);
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Error handling event of type {EventType} with ID {EventId}", eventType.Name, domainEvent.Id);
					throw;
				}
			}
		}

		public void Register<T>(IEventHandler<T> handler) where T : IDomainEvent
		{
			var eventType = typeof(T);

			if (!_handlers.ContainsKey(eventType))
			{
				_handlers[eventType] = new List<object>();
			}

			_handlers[eventType].Add(handler);
			_logger.LogInformation("Registered handler {HandlerType} for event {EventType}",
				handler.GetType().Name, eventType.Name);
		}
	}
}
