﻿namespace hoicham.Core.Ports.Output.Services
{
    public interface ILoggerService
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(Exception ex, string message, params object[] args);
    }
}
