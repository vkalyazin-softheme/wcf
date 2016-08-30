using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using CalcService;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebServiceHost(typeof(Calc), new Uri("http://localhost/Calc"));
            host.AddServiceEndpoint(typeof(ICalc), new WebHttpBinding(), "");
            host.Open();

            Console.WriteLine("{0}: Host is open.", DateTime.Now);

            Console.ReadLine();
        }
    }
}
