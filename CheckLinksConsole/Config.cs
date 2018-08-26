using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace CheckLinksConsole
{
    public class Config
    {
        public Config(string[] args)
        {
            var inMemory = new Dictionary<string, string>
            {
                { "site", "http://google.com" },
                { "output:folder", "reports" }
            };
            var configBuilder = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemory)
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("checksettings.json", optional: true, reloadOnChange: true)
                .AddCommandLine(args)
                .AddEnvironmentVariables();

            var configuration = configBuilder.Build();
            Site = configuration["site"];
            Output = configuration.GetSection("output").Get<OutputSettings>();
        }

        public string Site { get; set; }
        public OutputSettings Output { get; set; }
    }
}