namespace EventConnect.Application.Contracts.Logging;

public interface IAppLogger
{
    void LogInformation(string message, params object[] args);
    void LogWarning(string message, params object[] args);
}