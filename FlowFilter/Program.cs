using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FlowFilter.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FlowFilter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<FlowFilterContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception e)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseKestrel(options =>
                //{
                //    options.Limits.MaxConcurrentConnections = 100;
                //    options.Limits.MaxConcurrentUpgradedConnections = 100;
                //    options.Limits.MaxRequestBodySize = 10 * 1024;
                //    options.Limits.MinRequestBodyDataRate =
                //        new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                //    options.Limits.MinResponseDataRate =
                //        new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                //    options.Listen(IPAddress.Loopback, 5000);
                //    options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                //    {
                //        listenOptions.UseHttps("testCert.pfx", "11111111");
                //    });
                //})
                .UseStartup<Startup>();
    }
}
