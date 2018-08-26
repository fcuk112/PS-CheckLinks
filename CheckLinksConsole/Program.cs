using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CheckLinksConsole
{
    partial class Program
    {

        static void Main(string[] args)
        {
            var config = new Config(args);

            Logs.Init(config.ConfigurationRoot);

            var logger = Logs.Factory.CreateLogger<Program>();

            Directory.CreateDirectory(config.Output.GetReportDirectory());

            logger.LogInformation(200, $"Saving report to {config.Output.GetReportFilePath()}");

            var client = new HttpClient();
            var body = client.GetStringAsync(config.Site);

            var links = LinkChecker.GetLinks(config.Site, body.Result);

            var checkedLinks = LinkChecker.CheckLinks(links);
            using (var file = File.CreateText(config.Output.GetReportFilePath()))
            {
                foreach (var link in checkedLinks.OrderBy(l => l.Exists))
                {
                    var status = link.IsMissing ? "missing" : "OK";
                    file.WriteLine($"{status} - {link.Link}");
                }
            }
        }

    }
}
