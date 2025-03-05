using hoicham.Core.Ports.Output.Services;
using Microsoft.Extensions.Logging;

namespace hoicham.Adapter.Secondary.Service
{
	public class LoggerService : ILoggerService
	{
		private readonly ILogger<LoggerService> _logger;

		public LoggerService(ILogger<LoggerService> logger)
		{
			_logger = logger;
		}

		public void LogInformation(string message, params object[] args)
		{
			_logger.LogInformation(message, args);
		}

		public void LogWarning(string message, params object[] args)
		{
			_logger.LogWarning(message, args);
		}

		public void LogError(Exception ex, string message, params object[] args)
		{
			_logger.LogError(ex, message, args);
		}
	}
}
