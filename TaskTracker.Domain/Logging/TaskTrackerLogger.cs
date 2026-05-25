using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace TaskTracker.Domain.Logging
{

    public static class TaskTrackerLogger
    {
        public static void Log(
            ILogger logger,
            LogLevel level,
            Exception ex,
            [CallerFilePath] string callerPath = "",
            [CallerMemberName] string callerMemberName = ""
        )
        {
            var filePaths = callerPath.Split("/");
            var className = Path.GetFileNameWithoutExtension(filePaths[^1]);
            switch (level)
            {
                case LogLevel.Trace:
                    logger.LogTrace("[{LogLevel}][{CallerPath}][{CallerMemberName}]:{Message}", level, className, callerMemberName, ex);
                    break;
                case LogLevel.Debug:
                    logger.LogDebug("[{LogLevel}][{CallerPath}][{CallerMemberName}]: {Message}", level, className, callerMemberName, ex);
                    break;
                case LogLevel.Information:
                    logger.LogInformation("[{LogLevel}][{CallerPath}][{CallerMemberName}]:{Message}", level, className, callerMemberName, ex);
                    break;
                case LogLevel.Warning:
                    logger.LogWarning("[{LogLevel}][{CallerPath}][{CallerMemberName}]:{Message}", level, className, callerMemberName, ex);
                    break;
                case LogLevel.Error:
                    logger.LogError("[{LogLevel}][{CallerPath}][{CallerMemberName}]: {Message}", level, className, callerMemberName, ex);
                    break;
                case LogLevel.Critical:
                    logger.LogCritical("[{LogLevel}][{CallerPath}][{CallerMemberName}]: {Message}", level, className, callerMemberName, ex);
                    break;
                case LogLevel.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }
    }
}