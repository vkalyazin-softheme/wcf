using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using LogService;

namespace CalcService
{
    public class Calc : ICalc
    {
        public int Add(int a, int b)
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress("http://localhost/Logger");

            var calcChannelFactory = new ChannelFactory<ILogger>(binding, endpoint);

            var client = calcChannelFactory.CreateChannel();

            client.Log();

            return a + b;
        }
    }
}
