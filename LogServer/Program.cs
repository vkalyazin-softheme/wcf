﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using LogService;

namespace LogServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceType = typeof(Logger);
            var serviceUri = new Uri("http://localhost/Logger");
            var host = new ServiceHost(serviceType, serviceUri);
            host.AddDefaultEndpoints();
            host.Open();

            Console.WriteLine("{0}: Host is open.", DateTime.Now);

            Console.ReadLine();
        }
    }
}