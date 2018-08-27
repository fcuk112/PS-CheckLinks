using System;
using System.Collections.Generic;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace CheckLinksConsole
{
    partial class Program
    {

        static void Main(string[] args)
        {
            var config = new Config(args);
            Logs.Init(config.ConfigurationRoot);

            var host = CreateWebHostBuilder(args).Build();

            // RecurringJob.AddOrUpdate<CheckLinkJob>("check-link", j => j.Execute(config.Site, config.Output), Cron.Minutely);
            // RecurringJob.Trigger("check-link");
            RecurringJob.AddOrUpdate(() => Console.Write("Simple!"), Cron.Minutely);

            host.Run();

            // using (var server = new BackgroundJobServer())
            // {
            //     Console.WriteLine("Hangfire Server started.");
            //     host.Run();
            // }
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}
