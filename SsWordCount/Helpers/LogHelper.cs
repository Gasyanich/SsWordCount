using System;
using Microsoft.Extensions.Logging;

namespace SsWordCount.Helpers
{
    public static class LogHelper
    {
        /// <summary>
        /// Метод расширения для логгирования текста исключения со StackTrace'ом
        /// </summary>
        /// <param name="logger">Интерфейс логгера</param>
        /// <param name="e">Выброшенное исключение</param>
        public static void LogExceptionStackTrace(this ILogger logger, Exception e)
        {
            logger.LogError($"\nError:{e.Message}\nStacktrace:{e.StackTrace?.TrimStart()}\n");
        }
    }
}