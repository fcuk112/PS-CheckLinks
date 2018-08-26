﻿using System;
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
            var logger = Logs.Factory.CreateLogger<Program>();

            var config = new Config(args);
            Directory.CreateDirectory(config.Output.GetReportDirectory());
            var client = new HttpClient();
            var body = client.GetStringAsync(config.Site);

            var links = LinkChecker.GetLinks(config.Site, body.Result);
            return;

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
