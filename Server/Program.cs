using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using CalcService;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceType = typeof(Calc);
            var serviceUri = new Uri("http://localhost/Calc.svc");
            var host = new ServiceHost(serviceType, serviceUri);
            host.AddServiceEndpoint(typeof(ICalc), new WebHttpBinding(), "");
            host.Open();

            Console.WriteLine("{0}: Host is open.", DateTime.Now);

            Console.ReadLine();
        }
    }
}
