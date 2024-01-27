using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MK.RequirementsApp.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseStartup<Startup>().UseKestrel(options =>
                    //{
                    //    options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                    //    {
                    //        // Specify the path to your SSL certificate (.pfx file)
                    //        listenOptions.UseHttps("path/to/your/certificate.pfx", "your-certificate-password");
                    //    });
                    //});
                });
    }
}
