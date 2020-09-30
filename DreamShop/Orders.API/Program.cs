using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Orders.API
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
                    var Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
                    string ip = Configuration["ip"];
                    string port = Configuration["port"];
                    webBuilder.UseStartup<Startup>()
                    .UseUrls($"http://{ ip}:{port}");//配置ip地址和端口地址;
                });
    }
}
