using System;
using Microsoft.Extensions.Logging;

namespace SsWordCount.Helpers
{
    public static class LogHelper
    {
        public static void LogExceptionStackTrace(this ILogger logger, Exception e)
        {
            logger.LogError($"\nError:{e.Message}\nStacktrace:{e.StackTrace?.TrimStart()}\n");
        }
    }
}