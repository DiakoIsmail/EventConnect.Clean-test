using EventConnect.Application.Contracts.Logging;
using Microsoft.Extensions.Logging;

namespace EventConnect.Infrastructure.LoggerAdapter;

public class LoggerAdapter<T>: IAppLogger
{
    
    private readonly ILogger<T> _logger;
    public LoggerAdapter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<T>();
    }
    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message, args);
    }

    public void LogWarning(string message, params object[] args)
    {
        _logger.LogWarning(message, args);
    }
}