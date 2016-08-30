using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using CalcService;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress("http://localhost/Calc");

            var calcChannelFactory = new ChannelFactory<ICalc>(binding, endpoint);

            var client = calcChannelFactory.CreateChannel();

            while (true)
            {
                try
                {
                    var a = Convert.ToInt32(Console.ReadLine());
                    var b = Convert.ToInt32(Console.ReadLine());

                    var result = client.Add(a, b);

                    Console.WriteLine("Result: {0}.", result);
                    Console.WriteLine();

                    if (result == 0)
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input error.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Connection error.");
                }
            }

            Console.ReadLine();
        }
    }
}
