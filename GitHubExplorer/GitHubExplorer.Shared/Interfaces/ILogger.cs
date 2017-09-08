using System;

namespace GitHubExplorer.Shared.Interfaces
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogException(Exception ex);
    }
}
