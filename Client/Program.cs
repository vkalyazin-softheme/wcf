using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using CalcService;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var calcChannelFactory = new ChannelFactory<ICalc>(new WebHttpBinding(), "http://localhost/Calc");
            calcChannelFactory.Endpoint.Behaviors.Add(new WebHttpBehavior());

            var client = calcChannelFactory.CreateChannel();

            while (true)
            {
                try
                {
                    var a = Console.ReadLine();
                    var b = Console.ReadLine();

                    var result = Convert.ToInt32(client.Add(a, b));

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
