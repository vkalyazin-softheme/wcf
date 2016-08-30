using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using CalcService;
using LogService;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var loggerChannelFactory = new ChannelFactory<ILogger>(new WebHttpBinding(), "http://localhost/Logger");
            loggerChannelFactory.Endpoint.Behaviors.Add(new WebHttpBehavior());

            var calcChannelFactory = new ChannelFactory<ICalc>(new WebHttpBinding(), "http://localhost/Calc");
            calcChannelFactory.Endpoint.Behaviors.Add(new WebHttpBehavior());

            var calcClient = calcChannelFactory.CreateChannel();
            var logClient = loggerChannelFactory.CreateChannel();

            while (true)
            {
                try
                {
                    var a = Console.ReadLine();
                    var b = Console.ReadLine();

                    logClient.Log("From client.");

                    var result = Convert.ToInt32(calcClient.Add(a, b));

                    Console.WriteLine("Result: {0}.", result);
                    Console.WriteLine();

                    if (result == 0)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            Console.ReadLine();
        }
    }
}
