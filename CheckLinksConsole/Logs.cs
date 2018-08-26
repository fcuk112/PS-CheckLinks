using Microsoft.Extensions.Logging;

namespace CheckLinksConsole
{
    public static class Logs
    {
        public static LoggerFactory Factory = new LoggerFactory();
        static Logs()
        {
            Factory.AddConsole(minLevel: LogLevel.Trace, includeScopes: true);
            Factory.AddFile("logs/checklinks-{Date}.json",
                isJson: true,
                minimumLevel: LogLevel.Trace);
        }
    }
}