using Microsoft.Extensions.Logging;

namespace CheckLinksConsole
{
    public static class Logs
    {
        public static LoggerFactory Factory = new LoggerFactory();
        static Logs()
        {
            Factory.AddConsole(minLevel: LogLevel.Debug);
            Factory.AddFile("logs/checklinks-{Date}.txt", minimumLevel: LogLevel.Debug);

        }
    }
}