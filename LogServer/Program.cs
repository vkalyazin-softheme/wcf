using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
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
            var host = new WebServiceHost(serviceType, serviceUri);
            host.AddServiceEndpoint(typeof(ILogger), new WebHttpBinding(), "");
            host.Open();

            Console.WriteLine("{0}: Host is open.", DateTime.Now);

            Console.ReadLine();
        }
    }
}
