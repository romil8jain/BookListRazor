using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BookListRazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run(); //calls the function that returns the IHostBuilder object
                                                   //we build and run on that object
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => //IHostBuilder is defined as such:
            Host.CreateDefaultBuilder(args) //sets up the webhost default configuration
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); //webbuilder is configured to use startup class file
                });
    }
}
