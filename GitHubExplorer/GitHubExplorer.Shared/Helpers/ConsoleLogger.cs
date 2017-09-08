using GitHubExplorer.Shared.Interfaces;
using System;
using System.Diagnostics;

namespace GitHubExplorer.Shared.Helpers
{
    public class ConsoleLogger : ILogger
    {
        public void LogException(Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }

        public void LogInfo(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
