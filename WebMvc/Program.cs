﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebMvc
{
    public class Program
    {
        public static Dictionary<string, string> arrayDict = new Dictionary<string, string>
        {
            {"array:entries:0", "value0"},
            {"array:entries:1", "value1"},
            {"array:entries:2", "value2"},
            {"array:entries:4", "value4"},
            {"array:entries:5", "value5"}
        };
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, config) =>
            {
                config.AddInMemoryCollection(arrayDict);
                config.AddJsonFile("json_array.json", optional: false, reloadOnChange: false);
                //config.AddJsonFile("starship.json", optional: false, reloadOnChange: false);
                //config.AddXmlFile("tvshow.xml", optional: false, reloadOnChange: false);
                //config.AddEFConfiguration(options => options.UseInMemoryDatabase("InMemoryDb"));
                config.AddCommandLine(args);
            })
                .UseStartup<Startup>()
                .Build();
    }
}
