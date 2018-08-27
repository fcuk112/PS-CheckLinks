using System;
using System.Collections.Generic;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CheckLinksConsole
{
    partial class Program
    {

        static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            RecurringJob.Trigger("check-link");

            // RecurringJob.AddOrUpdate(() => Console.Write("Simple!"), Cron.Minutely);


            // var loggerFactory = host.Services.GetService<ILoggerFactory>();
            // loggerFactory.CreateLogger<Program>().LogInformation("Frank Testing!");

            RecurringJob.AddOrUpdate<CheckLinkJob>("check-link",
                j => j.Execute(),
                Cron.Minutely);

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
