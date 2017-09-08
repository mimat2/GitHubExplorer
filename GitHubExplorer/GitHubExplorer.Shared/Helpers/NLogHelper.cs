using NLog;
using System;

namespace GitHubExplorer.Shared.Helpers
{
    public class NLogHelper : Interfaces.ILogger
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogException(Exception ex)
        {
            logger.Error(ex);
        }
    }
}
