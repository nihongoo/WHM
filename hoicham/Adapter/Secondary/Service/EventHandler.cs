using hoicham.Core.Domain.Events;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Adapter.Secondary.Service
{
	public class EventHandler<T> : IEventHandler<T> where T : IDomainEvent
	{
		private readonly ILogger<EventHandler> _logger;

		public EventHandler(ILogger<EventHandler> logger)
		{
			_logger = logger;
		}

		public async Task HandleAsync(T domainEvent)
		{
			_logger.LogInformation($"Handling event: {domainEvent.GetType().Name}");
			await Task.CompletedTask;
		}
	}
}
