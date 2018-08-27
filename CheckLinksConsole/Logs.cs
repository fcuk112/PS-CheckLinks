using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CheckLinksConsole
{
    public static class Logs
    {
        public static void Init(ILoggerFactory factory, IConfiguration configuration)
        {
            factory.AddConsole(configuration.GetSection("Logging"));
            factory.AddFile("logs/checklinks-{Date}.json",
                isJson: true,
                minimumLevel: LogLevel.Trace);
        }
    }
}